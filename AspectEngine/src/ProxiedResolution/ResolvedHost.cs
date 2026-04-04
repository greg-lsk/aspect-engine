using System;


namespace AspectEngine.ProxiedResolution;

public delegate void HostedAction<T>(in T hosted) where T : struct;
public delegate void HostedAction<T, Arg01>(in T hosted, Arg01 arg01) where T : struct;

public struct ResolvedHost<T> : IDisposable where T : struct
{
    private bool _disposed ;
    private readonly T _resolved;


    private ResolvedHost(T resolved)
    {
        _disposed = false;
        _resolved = resolved;
    }
    public static ResolvedHost<T> Create(T resolved) => new(resolved);


    public readonly void Execute(HostedAction<T> hostedAction) => hostedAction(in _resolved);

    public void Dispose()
    {
        _disposed = true;
    }
}