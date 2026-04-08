namespace AspectEngine.ProxiedResolution;

public interface IResolutionMetadataUtills
{
    public ResolutionSource CreateResolutionSource<T>(IResolutionMetadata<T> resolutionMetadata, object? resolutionSource) 
        where T : struct;
}