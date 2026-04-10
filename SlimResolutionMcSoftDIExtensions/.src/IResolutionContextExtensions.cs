using Microsoft.Extensions.DependencyInjection;

using SlimResolutionCore;
using SlimResolutionMcSoftDIExtensions.Internals;


namespace SlimResolutionMcSoftDIExtensions;

public static class IResolutionContextExtensions
{
    public static IServiceCollection AddResolutionContext(this IServiceCollection services)
    {
        services.AddSingleton<IResolutionContext, ResolutionContext>(provider =>
        {
            return new(() => provider);
        });

        return services;
    }
}