using API.Models;

namespace API.Extensions;

public static class RequestContextExtensions
{
    public static IServiceCollection AddRequestContext(this IServiceCollection services) =>
        services
            .AddHttpContextAccessor()
            .AddScoped<RequestContext>();
}
