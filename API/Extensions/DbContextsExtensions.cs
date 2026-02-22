using API.DatabaseContexts;
using API.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Extensions;

public static class DbContextsExtensions
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services)
    {
        IOptions<DatabaseOptions> databaseOptions = services.BuildServiceProvider().GetRequiredService<IOptions<DatabaseOptions>>();

        services.AddDbContext<PostgresDbContext>(options =>
        {
            options.UseNpgsql(databaseOptions.Value.Postgres);
        });

        return services;
    }
}
