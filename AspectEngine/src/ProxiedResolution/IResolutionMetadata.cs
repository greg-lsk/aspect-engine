namespace AspectEngine.ProxiedResolution;

public interface IResolutionMetadata<T> where T : struct { }


public interface ICreator<T, TContext> 
    where T : struct
    where TContext : struct, IResolutionContext<T>
{
    public T Create(in TContext resolutionContext);
}