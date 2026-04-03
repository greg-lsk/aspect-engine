using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.DependencyInjection;

public interface IProxiedResolution<TResolved>
{
    public TResolved Create();
    public Wrap<TResolved> AsScoped();
}


public delegate IServiceScope CreateScope();
public delegate IServiceProvider SupplyProvider();
public delegate TResolved Resolve<TResolved>(SupplyProvider supplyProvider);

public abstract class ProxiedResolutionBase<TResolved>
{
    protected CreateScope CreateScope { get; }
    protected SupplyProvider SupplyProvider { get; }
    protected abstract Resolve<TResolved> Resolve { get; }


    protected ProxiedResolutionBase(CreateScope createScope, SupplyProvider supplyProvider)
    {
        CreateScope = createScope;
        SupplyProvider = supplyProvider;
    }


    public abstract TResolved Create();
    public Wrap<TResolved> AsScoped() => Wrap<TResolved>.Instance(CreateScope, Resolve);
}


public readonly struct Wrap<TResolved> : IDisposable
{
    private readonly IServiceScope _scope;
    private readonly SupplyProvider _supplyProvider;
    private readonly Resolve<TResolved> _resolve;


    private Wrap(CreateScope createScope, Resolve<TResolved> resolve)
    {
        var scope = createScope();

        _scope = scope;
        _supplyProvider = () => scope.ServiceProvider;
        _resolve = resolve;
    }
    internal static Wrap<TResolved> Instance(CreateScope createScope, Resolve<TResolved> resolve)
    {
        return new(createScope, resolve);
    }


    public TResolved Create() => _resolve(_supplyProvider);
    public void Dispose() => _scope.Dispose();
}