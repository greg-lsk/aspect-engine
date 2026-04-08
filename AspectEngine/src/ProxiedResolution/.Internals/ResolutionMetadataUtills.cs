namespace AspectEngine.ProxiedResolution.Internals;

internal class ResolutionMetadataUtills : IResolutionMetadataUtills
{
    public ResolutionSource CreateResolutionSource<T>(IResolutionMetadata<T> resolutionMetadata, object? resolutionSource) 
        where T : struct
    {
        var source = resolutionSource is not null 
            ? resolutionSource
            : (resolutionMetadata as ResolutionMetadata<T>).HostingContainer;
        return ResolutionSource.Create(source);
    }
    }
}