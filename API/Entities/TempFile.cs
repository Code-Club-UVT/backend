using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class TempFile
{
    public required Guid Id { get; init; }
    [StringLength(128)] public required string FileName { get; init; }
    [StringLength(8)] public required string Extension { get; init; }
    public required long SizeBytes { get; init; }
    public DateTime StoredAt { get; init; } = DateTime.UtcNow;

    public Guid HomeworkId { get; init; }
    public TempHomework? Homework { get; init; }
}
