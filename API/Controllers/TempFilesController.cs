using API.Database;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TempFilesController(
    PostgresDbContext dbContext
    ) : ControllerBase
{
    [HttpPost]
    [Route("{homeworkId:guid}")]
    public async Task<IActionResult> Post([FromRoute] Guid homeworkId, IFormFile file)
    {
        if (file.Length == 0)
            return BadRequest("No file uploaded.");

        Guid fileId = Guid.NewGuid();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
        string extension = Path.GetExtension(file.FileName).TrimStart('.');

        string extensionPath = Path.Combine("uploads", extension);
        Directory.CreateDirectory(extensionPath);

        string filePath = Path.Combine(extensionPath, $"{fileId}.{extension}");
        await using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        TempFile tempFile = new TempFile
        {
            Id = fileId,
            FileName = fileNameWithoutExtension,
            Extension = extension,
            SizeBytes = file.Length,
            HomeworkId = homeworkId
        };

        dbContext.TempFiles.Add(tempFile);
        await dbContext.SaveChangesAsync();

        return Ok(new { id = fileId, fileName = file.FileName, length = file.Length });
    }
}
