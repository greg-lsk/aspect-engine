namespace AspectEngine.ProxiedResolution;

public abstract class ResolutionMetadata<T> : IResolutionMetadata<T>
    where T : struct
{
    internal object HostingContainer { get; }
    internal Materialize<T> Materialize { get; }

    protected ResolutionMetadata(object hostingContainer, Materialize<T> materialize)
    {
        HostingContainer = hostingContainer;
        Materialize = materialize;
    }
}