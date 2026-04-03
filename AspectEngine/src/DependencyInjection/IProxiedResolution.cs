using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.DependencyInjection;


public interface IProxiedResolution<TResolved>
{
    public TResolved Create();
}

public interface IProxiedResolution<TContext, TResolved>
{
    public TResolved Create();
    
    public Wrap<TContext, TResolved, IProxiedResolution<TContext, TResolved>> AsScoped(); 

}


public delegate IServiceScope ScopeFactory();
public delegate IServiceProvider ProviderSource();
public abstract class ProxiedResolutionBase
{
    protected readonly ScopeFactory _scopeFactory;
    protected readonly ProviderSource _providerSource;

    protected ProxiedResolutionBase(ScopeFactory scopeFactory, ProviderSource providerSource)
    {
        _scopeFactory = scopeFactory;
        _providerSource = providerSource;
    }
}


public class Wrap<TContext, TResolved, TFactory> : IDisposable, IProxiedResolution<TContext, TResolved>
      where TFactory : IProxiedResolution<TContext, TResolved>
{
    private readonly IServiceScope _scope;
    private readonly TFactory _factory;

    public Wrap(IServiceScope scope, TFactory factory)
    {
        _scope = scope;
        _factory = factory;
    }

    public Wrap<TContext, TResolved, IProxiedResolution<TContext, TResolved>> AsScoped()
    {
        return _factory.AsScoped();
    }

    public TResolved Create() => _factory.Create();

    public void Dispose()
    {
        _scope.Dispose();
    }
}