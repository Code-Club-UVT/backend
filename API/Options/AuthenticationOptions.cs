namespace API.Options;

public class AuthenticationOptions
{
    public const string SectionName = "Authentication";

    public string Issuer { get; init; } = "";
    public string Audience { get; init; } = "";
    public string Secret { get; init; } = "";
}
