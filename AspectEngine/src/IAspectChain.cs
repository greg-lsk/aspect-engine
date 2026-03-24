namespace AspectEngine;

public interface IAspectChain<TData>
{
    public void Run(in TData data);
}