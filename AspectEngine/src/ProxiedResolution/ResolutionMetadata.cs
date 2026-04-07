namespace AspectEngine.ProxiedResolution;

public abstract class ResolutionMetadata<T> : IResolutionMetadata<T>
    where T : struct
{
    private readonly object _hostingContainer;

    internal object HostingContainer => _hostingContainer;


    protected ResolutionMetadata(object hostingContainer)
    {
        _hostingContainer = hostingContainer;
    }


    public abstract T Materialize(IResolutionMetadata<T> resolutionMetadata, in ResolutionSource resolutionSource);
}