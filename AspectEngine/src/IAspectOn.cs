namespace AspectEngine;

public interface IAspectMetadata 
{
    public void Run();
}

public interface IAspectOn<TData>
{
    public TData Context { get; }
}