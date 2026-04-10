using Microsoft.Extensions.DependencyInjection;
using AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection.Internals;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

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