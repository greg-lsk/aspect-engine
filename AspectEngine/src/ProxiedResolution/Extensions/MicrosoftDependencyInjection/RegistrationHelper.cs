using System;

using Microsoft.Extensions.DependencyInjection;
using AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection.Internals;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

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