using System;

using Microsoft.Extensions.DependencyInjection;
using AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection.Internals;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

public static class RegistrationHelper
{
    public static TS GenericResolution<TS>(IResolutionUtills metadataHandler) where TS : notnull
    {
        return (metadataHandler as ResolutionUtills).ResolutionSource().GetRequiredService<TS>();
    }

    internal static ResolutionUtills Create(Func<IServiceProvider> providerSelector)
    {
        return new(providerSelector);
    }
}