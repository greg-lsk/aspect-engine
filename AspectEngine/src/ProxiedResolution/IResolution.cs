namespace AspectEngine.ProxiedResolution;

public interface IResolution<T> where T : struct
{
    public T Run();
}