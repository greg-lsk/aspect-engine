namespace AspectEngine.ProxiedResolution;

public readonly struct ResolutionSource
{
    internal object? Instance { get; } = null;


    private ResolutionSource(object resolutionSource)
    {
        Instance = resolutionSource;
    }
    internal static ResolutionSource Create<T>(IResolutionMetadata<T> resolutionMetadata, object? resolutionSource) 
        where T : struct
    {
        var source = resolutionSource is not null 
            ? resolutionSource 
            : (resolutionMetadata as ResolutionMetadata<T>).HostingContainer;

        return new(source);
    }
}