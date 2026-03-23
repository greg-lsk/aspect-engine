using AspectEngine.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

internal readonly struct EvaluationLoggingDependencies : IInjectableMetadata
{
    private readonly IServiceProvider _serviceProvider;

    private EvaluationLoggingDependencies(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public Microsoft.Extensions.Logging.ILogger Logger => _serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger>();
}