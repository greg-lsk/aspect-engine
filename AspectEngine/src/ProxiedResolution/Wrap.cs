using System;


namespace AspectEngine.ProxiedResolution;

public readonly struct Wrap<T> : IDisposable
{
    private readonly SupplyProvider _supplyProvider;
    private readonly Resolve<T> _resolve;


    private Wrap(CreateScope createScope, Resolve<T> resolve)
    {
        var scope = createScope();

        _supplyProvider = () => scope.ServiceProvider;
        _resolve = resolve;
    }
    internal static Wrap<T> Instance(CreateScope createScope, Resolve<T> resolve)
    {
        return new(createScope, resolve);
    }


    public T Resolve() => _resolve(_supplyProvider);
    public void Dispose() { }
}