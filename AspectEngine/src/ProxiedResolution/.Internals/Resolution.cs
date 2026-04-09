namespace AspectEngine.ProxiedResolution.Internals;

internal class Resolution<T> : IResolution<T> where T : struct
{
    private readonly IResolutionMetadata<T> _metadata;
    private readonly IResolutionMetadataHandler _metadataHandler;


    public Resolution(IResolutionMetadata<T> metadata, IResolutionMetadataHandler metadataHandler)
    {
        _metadata = metadata;
        _metadataHandler = metadataHandler;
    }


    public T Invoke() => _metadata.Materialize(_metadataHandler);
}