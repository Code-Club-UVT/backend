using API.DatabaseContexts;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TempHomeworkController(
    PostgresDbContext dbContext
) : ControllerBase
{
    [HttpGet]
    [Route("{number:long}")]
    public async Task<IActionResult> GetByNumber([FromRoute] long number)
    {
        var tempHomework = await dbContext.TempHomeworks.FirstOrDefaultAsync(h => h.Number == number);
        if (tempHomework == null)
            return NotFound();

        return Ok(new { id = tempHomework.Id, number = tempHomework.Number, title = tempHomework.Title, description = tempHomework.Description });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] string title, [FromForm] string description)
    {
        long nextNumber = dbContext.TempFiles.Count() + 1;

        TempHomework tempHomework = new TempHomework
        {
            Number = nextNumber,
            Title = title,
            Description = description
        };

        dbContext.TempHomeworks.Add(tempHomework);
        await dbContext.SaveChangesAsync();

        return Ok(new { id = tempHomework.Id, number = tempHomework.Number, title = tempHomework.Title, description = tempHomework.Description });
    }
}
