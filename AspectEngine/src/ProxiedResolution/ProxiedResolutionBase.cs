namespace AspectEngine.ProxiedResolution;

public abstract class ProxiedResolutionBase<T> where T : struct
{
    public SupplyProvider SupplyRootProvider { get; }


    protected ProxiedResolutionBase(SupplyProvider supplyProvider)
    {
        SupplyRootProvider = supplyProvider;
    }
}