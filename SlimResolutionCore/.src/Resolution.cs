namespace SlimResolutionCore;

public delegate T Resolution<T>(IResolutionContext context) where T : notnull;