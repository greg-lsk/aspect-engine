using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionMetadataExtensions
{
    public static T Create<T>(this IResolutionMetadata<T> resolutionMetadata, IServiceScope scope) where T : struct
    {
        var context = new ResolutionContext<T>(scope, resolutionMetadata);
        return resolutionMetadata.Create(context);
    }
}