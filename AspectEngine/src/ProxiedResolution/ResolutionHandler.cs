namespace AspectEngine.ProxiedResolution;

public readonly struct ResolutionHandler
{
    public static ResolutionHandler Create() => new();


    public TService Execute<TService>(Resolution<TService> resolution, in ResolutionSource resolutionSource)
    {
        return resolution(resolutionSource.Instance);
    }
}