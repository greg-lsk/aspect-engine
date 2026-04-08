using AspectEngine.ProxiedResolution.Internals;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionExtensions
{
    public static IServiceCollection AddResolution(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IResolution<>), typeof(Resolution<>));
        return services;
    }
}