namespace AspectEngine.ProxiedResolution;

public delegate T Resolution<T>(object serviceProvider);
public delegate T MetaResolution<T>(in ResolutionSource resolutionSource);