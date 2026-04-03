namespace AspectEngine.DependencyInjection;

public interface IServiceFactory<TContext, TService>
{
    public TService Create(in TContext context);
}