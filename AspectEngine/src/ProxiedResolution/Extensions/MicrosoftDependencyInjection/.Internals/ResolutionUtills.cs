using System;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection.Internals;

internal class ResolutionUtills : IResolutionUtills
{
    internal Func<IServiceProvider> ResolutionSource { get; }


    public ResolutionUtills(Func<IServiceProvider> resolutionSource)
    {
        ResolutionSource = resolutionSource;
    }
}