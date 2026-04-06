namespace AspectEngine.ProxiedResolution;

public interface IResolutionContext<T> where T : struct
{
    public IResolutionMetadata<T> ResolutionMetadata { get; }


    /*NEEDS:: extendable methods for different Service-Providers (????)*/
    public object Run(Resolution resolution);
}