using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class IResolutionMetadataExtensions
{
    public static IResolution<T> Materialize<T>(this IResolutionMetadata<T> resolutionMetadata, IServiceScope scope) where T : struct
    {
        throw new NotImplementedException();
    }
}