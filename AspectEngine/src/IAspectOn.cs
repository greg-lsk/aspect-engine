namespace AspectEngine;

public interface IAspectOn<TData>
{
    public TData Context { get; }
}