namespace AspectEngine.ProxiedResolution.Internals;

internal class Resolution<T> : IResolution<T> where T : struct
{
    private readonly IResolutionMetadata<T> _resolutionMetadata;


    public Resolution(IResolutionMetadata<T> resolutionMetadata)
    {
        _resolutionMetadata = resolutionMetadata;
    }


    public T Run() => _resolutionMetadata.Materialize();
}