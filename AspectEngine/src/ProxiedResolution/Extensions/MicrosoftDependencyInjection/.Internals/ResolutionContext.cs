using System;


namespace AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection.Internals;

internal class ResolutionContext : IResolutionContext
{
    internal Func<IServiceProvider> ProviderSelector { get; }


    public ResolutionContext(Func<IServiceProvider> providerSelector)
    {
        ProviderSelector = providerSelector;
    }
}