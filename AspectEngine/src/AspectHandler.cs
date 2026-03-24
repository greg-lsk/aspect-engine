using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine;

public class AspectHandler
{
    private readonly IServiceProvider _serviceProvider;


    public AspectExecutionEnvironment<TData> CreateEnvironment<TData>(TData data)
    {
        return AspectExecutionEnvironment<TData>.Create(data);
    }

    public TService ResolveDependency<TService>() where TService : notnull
    {
        return _serviceProvider.GetRequiredService<TService>();
    }
}