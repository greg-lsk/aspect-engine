namespace AspectEngine.ProxiedResolution.Internals;

internal class Resolution<T> : IResolution<T> where T : struct
{
    private readonly IResolutionMetadata<T> _metadata;
    private readonly IResolutionUtills _utills;


    public Resolution(IResolutionMetadata<T> metadata, IResolutionUtills utills)
    {
        _metadata = metadata;
        _utills = utills;
    }


    public T Invoke() => _metadata.Materialize(_utills);
}