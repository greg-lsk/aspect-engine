namespace AspectEngine.ProxiedResolution;

public interface IResolutionMetadataHandler
{
    public TService Execute<TService>(ServiceResolution<TService> resolution) where TService : class;
}