namespace AspectEngine.DependencyInjection;

public interface IWithServices<T> where T : IServicesMetadata
{
    public T Services { get; }
}