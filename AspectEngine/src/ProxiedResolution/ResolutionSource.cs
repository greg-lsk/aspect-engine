namespace AspectEngine.ProxiedResolution;

public readonly struct ResolutionSource
{
    internal object? Instance { get; } = null;


    private ResolutionSource(object resolutionSource)
    {
        Instance = resolutionSource;
    }
    internal static ResolutionSource Create(object? resolutionSource)
    {
        return new(resolutionSource);
    }
}