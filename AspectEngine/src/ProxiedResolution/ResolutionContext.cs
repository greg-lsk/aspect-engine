namespace AspectEngine.ProxiedResolution;

public class ResolutionContext<T> : IResolutionContext<T>, IResolution<T> where T : struct
{
    private readonly object _resolutionProvider;
    private readonly IResolutionMetadata<T> _resolutionMetadata;

    public object ResolutionProvider => _resolutionProvider;
    public T Result => ResolutionMetadata.Create(this);


    public ResolutionContext(object resolutionProvider, IResolutionMetadata<T> resolutionMetadata)
    {
        _resolutionProvider = resolutionProvider;
        _resolutionMetadata = resolutionMetadata;
    }


    public IResolutionMetadata<T> ResolutionMetadata => _resolutionMetadata;

    public object Run(Resolution resolution) => resolution(_resolutionProvider);
}