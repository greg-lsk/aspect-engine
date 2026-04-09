using Microsoft.Extensions.DependencyInjection;
using AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection.Internals;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionMetadataHandlerExtensions
{
    public static IServiceCollection AddResolutionMetadataHandler(this IServiceCollection services)
    {
        services.AddSingleton<IResolutionUtills, ResolutionUtills>(provider =>
        {
            return new(() => provider);
        });
        return services;
    }
}