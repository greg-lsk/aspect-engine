namespace AspectEngine.ProxiedResolution;

public interface IResolver<TContext, T>
    where T : struct
    where TContext : struct, IResolutionContext<T>
{
    public T Resolve(in TContext resolutionContext);
}