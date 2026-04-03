using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.DependencyInjection;

public interface IProxiedResolution<T>
{
    public T Resolve();
    public Wrap<T> AsScoped();
}


public delegate IServiceScope CreateScope();
public delegate IServiceProvider SupplyProvider();
public delegate T Resolve<T>(SupplyProvider supplyProvider);

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


public readonly struct Wrap<T> : IDisposable
{
    private readonly IServiceScope _scope;
    private readonly SupplyProvider _supplyProvider;
    private readonly Resolve<T> _resolve;


    private Wrap(CreateScope createScope, Resolve<T> resolve)
    {
        var scope = createScope();

        _scope = scope;
        _supplyProvider = () => scope.ServiceProvider;
        _resolve = resolve;
    }
    internal static Wrap<T> Instance(CreateScope createScope, Resolve<T> resolve)
    {
        return new(createScope, resolve);
    }


    public T Resolve() => _resolve(_supplyProvider);
    public void Dispose() => _scope.Dispose();
}