namespace AspectEngine.ProxiedResolution;

public abstract class ProxiedResolutionBase<T>
{
    protected CreateScope CreateScope { get; }
    protected SupplyProvider SupplyProvider { get; }
    protected abstract Resolve<T> Resolution { get; }


    protected ProxiedResolutionBase(CreateScope createScope, SupplyProvider supplyProvider)
    {
        CreateScope = createScope;
        SupplyProvider = supplyProvider;
    }


    public abstract T Resolve();
    public Wrap<T> AsScoped() => Wrap<T>.Instance(CreateScope, Resolution);
}