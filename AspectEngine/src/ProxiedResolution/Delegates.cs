namespace AspectEngine.ProxiedResolution;

public delegate T ServiceResolution<T>(object serviceProvider) where T : class;