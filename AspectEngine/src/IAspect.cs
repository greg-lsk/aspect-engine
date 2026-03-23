namespace AspectEngine;

public interface IAspectMetadata { }

internal interface IAspect<TData> : IAspectMetadata
{
    public void Run(in TData data);
}