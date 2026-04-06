using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionMetadataExtensions
{
    public static T Materialize<T>(this IResolutionMetadata<T> resolutionMetadata, IServiceScope? scope = null) where T : struct
    {
        var context = ResolutionContext<T>.Create(scope, resolutionMetadata as ResolutionMetadata<T>);
        return (resolutionMetadata as IResolver<ResolutionContext<T>, T>).Resolve(in context);
    }
}