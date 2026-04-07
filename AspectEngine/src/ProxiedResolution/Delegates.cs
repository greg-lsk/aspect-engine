namespace AspectEngine.ProxiedResolution;

public delegate T Resolution<T>(object serviceProvider);
public delegate T MetaResolution<T>(in ResolutionSource resolutionSource);

public delegate T Materialize<T>(IResolutionMetadata<T> resolutionMetadata, object? resolutionSource) where T : struct;