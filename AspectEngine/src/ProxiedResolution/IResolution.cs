namespace AspectEngine.ProxiedResolution;

public interface IResolution<T> where T : struct
{
    public T Result { get; }
}