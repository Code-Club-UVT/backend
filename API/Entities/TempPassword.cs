namespace API.Entities;

public class TempPassword
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Password { get; init; }
}
