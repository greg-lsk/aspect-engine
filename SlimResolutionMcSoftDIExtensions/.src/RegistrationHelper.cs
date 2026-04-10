using System;

using SlimResolutionCore;
using SlimResolutionMcSoftDIExtensions.Internals;

using Microsoft.Extensions.DependencyInjection;


namespace SlimResolutionMcSoftDIExtensions;

public static class RegistrationHelper
{
    public static TService GenericResolution<TService>(IResolutionContext context) 
        where TService : notnull
    {
        return (context as ResolutionContext).ProviderSelector().GetRequiredService<TService>();
    }

    internal static ResolutionContext CreateContext(Func<IServiceProvider> providerSelector)
    {
        return new(providerSelector);
    }
}