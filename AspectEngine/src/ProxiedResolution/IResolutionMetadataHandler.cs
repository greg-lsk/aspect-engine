namespace AspectEngine.ProxiedResolution;

public interface IResolutionMetadataHandler
{
    public TService Execution<TService>(ServiceResolution<TService> resolution) where TService : class;
}