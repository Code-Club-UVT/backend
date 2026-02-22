using API.Options;

namespace API.Extensions;

public static class OptionsExtensions
{
    public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
}
