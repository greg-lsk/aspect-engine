namespace AspectEngine.ProxiedResolution;

public interface IResolutionMetadata<T> where T : struct 
{ 
    public T Materialize(IResolutionMetadataHandler metadataHandler);
}