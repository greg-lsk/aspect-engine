using Microsoft.Extensions.DependencyInjection;

using SlimResolutionCore;
using SlimResolutionCore.src.ExtensionHelpers;


namespace SlimResolutionMcSoftDIExtensions;

public static class IComposerExtensions
{
    public static TResolved ComposeFor<TResolved>(this IComposer<TResolved> composer, IServiceScope scope)
        where TResolved : struct
    {
        var context = RegistrationHelper.CreateContext(() => scope.ServiceProvider);

        return ExtensionContext.Instance.Matarialize(composer, context);
    }

    public static IServiceCollection AddComposer(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IComposer<>), ExtensionContext.Instance.GetComposerType());
        return services;
    }
}