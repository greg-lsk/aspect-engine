using Microsoft.Extensions.DependencyInjection;
using AspectEngine.ProxiedResolution.Internals;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionExtensions
{
    public static TResolved Invoke<TResolved>(this IResolution<TResolved> resolution, IServiceScope scope)
        where TResolved : struct
    {
        var utill = RegistrationHelper.Create(() => scope.ServiceProvider);

        return (resolution as Resolution<TResolved>).Metadata.Materialize(utill);
    }

    public static IServiceCollection AddResolution(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IResolution<>), typeof(Resolution<>));
        return services;
    }
}