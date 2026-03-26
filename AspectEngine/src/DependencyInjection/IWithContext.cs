namespace AspectEngine.DependencyInjection;

public interface IWithContext<T>
{
    public T Context { get; }
}