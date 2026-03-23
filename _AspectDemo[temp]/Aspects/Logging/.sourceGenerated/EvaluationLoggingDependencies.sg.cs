using AspectEngine.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

internal readonly struct EvaluationLoggingDependencies : IEvaluationLoggingDependencies, IInjectableMetadata
{
    private readonly IServiceProvider _serviceProvider;

    internal EvaluationLoggingDependencies(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public Microsoft.Extensions.Logging.ILogger Logger => _serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger>();
}