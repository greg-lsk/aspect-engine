using System;


namespace AspectEngine.ProxiedResolution;

public readonly struct Wrap<T> : IDisposable
{
    private readonly SupplyProvider _supplyProvider;
    private readonly Resolve<T> _resolve;


    private Wrap(SupplyScope supplyScope, Resolve<T> resolve)
    {
        var scope = supplyScope();

        _supplyProvider = () => scope.ServiceProvider;
        _resolve = resolve;
    }
    internal static Wrap<T> Instance(SupplyScope supplyScope, Resolve<T> resolve)
    {
        return new(supplyScope, resolve);
    }


    public T Resolve() => _resolve(_supplyProvider);
    public void Dispose() { }
}