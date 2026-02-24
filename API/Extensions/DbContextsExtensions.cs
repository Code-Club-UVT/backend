using API.DatabaseContexts;
using API.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Extensions;

public static class DbContextsExtensions
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseOptions? databaseOptions = configuration.GetSection(DatabaseOptions.SectionName).Get<DatabaseOptions>();

        services.AddDbContext<PostgresDbContext>(options =>
        {
            options.UseNpgsql(databaseOptions?.Postgres);
        });

        return services;
    }
}
