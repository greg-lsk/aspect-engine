namespace AspectEngine.ProxiedResolution.Internals;

internal class Resolution<T> : IResolution<T> where T : struct
{
    internal readonly IResolutionMetadata<T> Metadata;
    internal readonly IResolutionUtills Utills;


    public Resolution(IResolutionMetadata<T> metadata, IResolutionUtills utills)
    {
        Metadata = metadata;
        Utills = utills;
    }


    public T Invoke() => Metadata.Materialize(Utills);
}