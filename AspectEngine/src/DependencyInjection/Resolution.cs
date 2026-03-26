using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.DependencyInjection;

public class Resolution
{
    private readonly IServiceProvider _serviceProvider;

    public TService For<TService>() where TService : notnull
    {
        return _serviceProvider.GetRequiredService<TService>();
    }
}