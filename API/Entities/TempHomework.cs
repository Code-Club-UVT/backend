using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class TempHomework
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required long Number { get; init; }
    [StringLength(64)] public required string Title { get; init; }
    [StringLength(4096)] public required string Description { get; init; }
}
