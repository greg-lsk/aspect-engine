using AspectEngine.ProxiedResolution.Internals;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionMetadataHandlerExtensions
{
    public static IServiceCollection AddResolutionMetadataHandler(this IServiceCollection services)
    {
        services.AddSingleton<IResolutionMetadataHandler, ResolutionMetadataHandler>(provider =>
        {
            return new(() => provider);
        });
        return services;
    }
}
