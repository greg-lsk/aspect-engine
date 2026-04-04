namespace AspectEngine.ProxiedResolution;

public interface IProxiedResolution<T> where T : struct
{
    public ResolvedHost<T> CreateHost(SupplyScope? supplyScope = null);
}