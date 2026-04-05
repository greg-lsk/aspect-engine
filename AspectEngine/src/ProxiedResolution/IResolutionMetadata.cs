namespace AspectEngine.ProxiedResolution;

public interface IResolutionMetadata<T> where T : struct
{
    public SessionOn<T> CreateSession(SupplyScope? supplyScope = null);
}