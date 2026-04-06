namespace AspectEngine.ProxiedResolution;

public readonly struct ResolutionContext<T> : IResolutionContext<T> where T : struct
{
    private readonly object _resolutionProvider;
    private readonly IResolutionMetadata<T> _resolutionMetadata;

    public IResolutionMetadata<T> ResolutionMetadata => _resolutionMetadata;


    private ResolutionContext(object resolutionProvider, IResolutionMetadata<T> resolutionMetadata)
    {
        _resolutionProvider = resolutionProvider;
        _resolutionMetadata = resolutionMetadata;
    }
    public static ResolutionContext<T> Create(object? resolutionProvider, ResolutionMetadata<T> resolutionMetadata)
    {
        var resolutionSource = resolutionProvider is not null 
            ? resolutionProvider 
            : resolutionMetadata.HostingContainer;

        return new(resolutionSource, resolutionMetadata);
    }


    public object Run(Resolution resolution) => resolution(_resolutionProvider);
}