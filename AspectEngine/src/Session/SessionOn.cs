using System;


namespace AspectEngine.Session;

public delegate void SessionCallback<THosted>(in THosted hosted);
public delegate void SessionCallback<THosted, T>(in THosted hosted, T arg);
public delegate void SessionCallback<THosted, T01, T02>(in THosted hosted, T01 arg01, T02 arg02);

public struct SessionOn<THosted> : IDisposable
{
    private bool _disposed ;
    private readonly THosted _hosted;


    private SessionOn(in THosted entity)
    {
        _disposed = false;
        _hosted = entity;
    }
    public static SessionOn<THosted> Create(in THosted entity)
    {
        return new(in entity);
    }


    public readonly void Execute(SessionCallback<THosted> hostedAction)
    {
        ThrowIfDisposed();
        hostedAction(in _hosted);
    }
    public readonly void Execute<T>(SessionCallback<THosted, T> hostedAction, T arg)
    {
        ThrowIfDisposed();
        hostedAction(in _hosted, arg);
    }
    public readonly void Execute<T01, T02>(SessionCallback<THosted, T01, T02> hostedAction, T01 arg01, T02 arg02)
    {
        ThrowIfDisposed();
        hostedAction(in _hosted, arg01, arg02);
    }


    public void Dispose()
    {
        _disposed = true;
    }


    private readonly void ThrowIfDisposed()
    {
        if (_disposed) throw new ObjectDisposedException(GetType().FullName);
    }
}