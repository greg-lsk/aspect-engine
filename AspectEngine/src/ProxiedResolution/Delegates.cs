namespace AspectEngine.ProxiedResolution;

public delegate T ServiceResolution<T>(IResolutionUtills metadataHandler) where T : notnull;