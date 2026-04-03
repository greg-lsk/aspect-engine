namespace AspectEngine;

public interface IAspect
{
    public void Run();
}

public interface IAspect<T>
{
    public void Run(in T context);
}