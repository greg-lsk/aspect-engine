namespace AspectEngine.DependencyInjection;

public interface IProxiedResolution<TContext, TResolved>
{
    public TResolved Create(in TContext context);
}

public interface IProxiedResolution<TResolved>
{
    public TResolved Create();
}