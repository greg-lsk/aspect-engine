namespace AspectEngine;

public interface IAspectMetadata { }

public interface IAspect<TData> : IAspectMetadata
{
    public void Run(in TData data);
}