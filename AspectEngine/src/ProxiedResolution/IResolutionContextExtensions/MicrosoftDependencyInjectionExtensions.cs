using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution.IResolutionContextExtensions;

public static class MicrosoftDependencyInjectionExtensions
{
    public static IResolution<T> CreateContext<T>(this IResolutionMetadata<T> resolutionMetadata, IServiceScope scope) where T : struct
    {
        throw new NotImplementedException();
    }
}