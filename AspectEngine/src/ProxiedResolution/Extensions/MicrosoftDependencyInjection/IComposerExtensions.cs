using Microsoft.Extensions.DependencyInjection;
using AspectEngine.ProxiedResolution.Internals;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IComposerExtensions
{
    public static TResolved ComposeFor<TResolved>(this IComposer<TResolved> composer, IServiceScope scope)
        where TResolved : struct
    {
        var context = RegistrationHelper.CreateContext(() => scope.ServiceProvider);

        return (composer as Composer<TResolved>).Metadata.Materialize(context);
    }

    public static IServiceCollection AddComposer(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IComposer<>), typeof(Composer<>));
        return services;
    }
}