namespace AspectEngine.ProxiedResolution;

public interface IResolutionContextHolder<T> where T : struct
{
    public IResolutionContext<T> ResolutionContext { get; }
}