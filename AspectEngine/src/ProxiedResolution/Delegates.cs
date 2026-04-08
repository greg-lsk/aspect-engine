namespace AspectEngine.ProxiedResolution;

public delegate T PropertyResolution<T>(object serviceProvider);
public delegate T MetaResolution<T>(in ResolutionSource resolutionSource);

public delegate T Materialize<T>(IResolutionMetadata<T> resolutionMetadata, object? resolutionSource) where T : struct;