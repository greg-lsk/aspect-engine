namespace AspectEngine.ProxiedResolution;

public interface IProxiedResolution<T>
{
    public T Resolve();
    public Wrap<T> AsScoped();
}