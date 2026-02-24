using API.Services;

namespace API.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<TestService>();
}
