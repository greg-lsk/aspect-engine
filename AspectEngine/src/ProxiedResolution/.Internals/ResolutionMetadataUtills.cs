namespace AspectEngine.ProxiedResolution.Internals;

internal class ResolutionMetadataUtills : IResolutionMetadataUtills
{
    internal ResolutionMetadataUtills() { }


    public ResolutionSource CreateResolutionSource<T>(IResolutionMetadata<T> resolutionMetadata, object? resolutionSource) 
        where T : struct
    {
        return ResolutionSource.Create(resolutionMetadata, resolutionSource);
    }
}