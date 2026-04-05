namespace AspectEngine.ProxiedResolution;

public abstract class ProxiedResolutionBase
{
    protected SupplyProvider SupplyRootProvider { get; }


    protected ProxiedResolutionBase(SupplyProvider supplyProvider)
    {
        SupplyRootProvider = supplyProvider;
    }
}