namespace API.Options;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public string Postgres { get; init; } = "";
}
