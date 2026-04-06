namespace AspectEngine.ProxiedResolution;

public interface IResolutionContextHolder<T, TContext> 
    where T : struct
    where TContext : struct, IResolutionContext<T>
{
    public TContext ResolutionContext { get; }
}