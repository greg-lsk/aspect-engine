using System;


namespace AspectEngine;

public interface IAspectChain<TData>
{
    public void Run(in TData data);
}

public static class AspectChain
{
    internal static Func<IServiceProvider>? GetServiceProvider;

    public static AspectExecutionEnvironment<TData> For<TData>(TData data)
    {
        var provider = GetServiceProvider is not null ? GetServiceProvider() 
                                                      : throw new InvalidOperationException();

        return AspectExecutionEnvironment<TData>.Create(data, provider);
    }
}