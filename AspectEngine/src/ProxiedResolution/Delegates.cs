namespace AspectEngine.ProxiedResolution;

public delegate T ServiceResolution<T>(IResolutionContext context) where T : notnull;