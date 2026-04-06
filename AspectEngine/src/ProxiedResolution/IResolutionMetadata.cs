namespace AspectEngine.ProxiedResolution;

public interface IResolutionMetadata<T> where T : struct { }

public interface ICreator<T> where T : struct
{
    public T Create(in IResolutionContext<T> resolutionContext);
}