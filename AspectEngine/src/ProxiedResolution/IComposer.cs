namespace AspectEngine.ProxiedResolution;

public interface IComposer<T> where T : struct
{
    public T Compose();
}