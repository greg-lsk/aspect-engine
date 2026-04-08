using AspectEngine.ProxiedResolution.Internals;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionMetadataUtillsExtensions
{
    public static IServiceCollection AddResolutionMetadataUtills(this IServiceCollection services)
    {
        services.AddSingleton<IResolutionMetadataUtills, ResolutionMetadataUtills>();
        return services;
    }
}