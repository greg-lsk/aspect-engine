using System;


namespace AspectEngine.ProxiedResolution.Internals;

internal class ResolutionMetadataHandler : IResolutionMetadataHandler
{
    private readonly Func<object> _resolutionSource;


    public ResolutionMetadataHandler(Func<object> resolutionSource)
    {
        _resolutionSource = resolutionSource;
    }


    public TService Execute<TService>(ServiceResolution<TService> resolution) where TService : class
    {
        return resolution(_resolutionSource());
    }
}