namespace AspectEngine.ProxiedResolution;

public class ResolutionContext<T> : IResolutionContext<T> where T : struct
{
    private readonly object _resolutionProvider;
    private readonly IResolutionMetadata<T> _resolutionMetadata;

    public IResolutionMetadata<T> ResolutionMetadata => _resolutionMetadata;


    public ResolutionContext(object resolutionProvider, IResolutionMetadata<T> resolutionMetadata)
    {
        _resolutionProvider = resolutionProvider;
        _resolutionMetadata = resolutionMetadata;
    }


    public object Run(Resolution resolution) => resolution(_resolutionProvider);
}