namespace AspectEngine.DependencyInjection;

public interface IInjectWith<TDependencies> where TDependencies : IInjectableMetadata
{
    public TDependencies Dependencies { get; }
}