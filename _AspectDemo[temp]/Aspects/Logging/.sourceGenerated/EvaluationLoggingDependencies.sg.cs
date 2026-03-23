using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

internal readonly struct EvaluationLoggingDependencies : IInjectableMetadata
{
    private readonly IServiceProvider _serviceProvider;

    private EvaluationLoggingDependencies(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public Microsoft.Extensions.Logging.ILogger Logger 
        => (Microsoft.Extensions.Logging.ILogger) _serviceProvider.GetService(typeof(Microsoft.Extensions.Logging.ILogger));
}