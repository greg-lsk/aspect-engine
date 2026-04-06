namespace AspectEngine.ProxiedResolution;

public interface ISessionColleague<T> where T : struct
{
    public IResolutionContext<T> ResolutionContext { get; }
}


public interface IResolutionContext<T> where T : struct
{
    public IResolutionMetadata<T> ResolutionMetadata { get; }


    /*NEEDS:: extendable methods for different Service-Providers (????)*/
    public object Run(Resolution resolution);
}

public interface IResolution<T> where T : struct
{
    public T Result { get; }
}

public class ResolutionContext<T> : IResolutionContext<T>, IResolution<T> where T : struct
{
    private readonly object _resolutionProvider;
    private readonly IResolutionMetadata<T> _resolutionMetadata;

    public object ResolutionProvider => _resolutionProvider;
    public T Result => ResolutionMetadata.Create(this);


    public ResolutionContext(object resolutionProvider, IResolutionMetadata<T> resolutionMetadata)
    {
        _resolutionProvider = resolutionProvider;
        _resolutionMetadata = resolutionMetadata;
    }


    public IResolutionMetadata<T> ResolutionMetadata => _resolutionMetadata;

    public object Run(Resolution resolution) => resolution(_resolutionProvider);
}