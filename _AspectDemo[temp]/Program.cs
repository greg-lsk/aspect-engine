using AspectDemo.Aspects.Logging;
using AspectEngine.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddSingleton<IEvaluationLoggingFactory, EvaluationLoggingFactory>(provider =>
{
    IServiceProvider providerSource() => provider;
    ILogger loggerResolution(ProviderSource ps) => ps().GetRequiredService<ILogger>();

    return new(provider.CreateScope, providerSource, loggerResolution);
});

var factory = services[0] as IEvaluationLoggingFactory;

using (var scopedFactory = factory!.AsScoped())
{
    var ev = scopedFactory.Create();
    ev.Run(18);
}