namespace AspectEngine.ProxiedResolution;

public abstract class ProxiedResolutionBase<T>
{
    protected SupplyProvider SupplyProvider { get; }
    protected abstract Resolve<T> Resolution { get; }


    protected ProxiedResolutionBase(SupplyProvider supplyProvider)
    {
        SupplyProvider = supplyProvider;
    }


    public abstract T Resolve();
    public Wrap<T> AsScoped(CreateScope createScope) => Wrap<T>.Instance(createScope, Resolution);
}