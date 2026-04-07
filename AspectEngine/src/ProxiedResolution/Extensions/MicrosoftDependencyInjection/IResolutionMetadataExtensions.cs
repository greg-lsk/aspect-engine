using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionMetadataExtensions
{
    public static T Materialize<T>(this IResolutionMetadata<T> resolutionMetadata, IServiceScope? scope = null) 
        where T : struct
    {
        var source = ResolutionSource.Create(resolutionMetadata, scope);
        return resolutionMetadata.Materialize(resolutionMetadata, in source);
    }
}