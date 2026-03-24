using AspectEngine;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

internal readonly struct EvaluationLoggingDependencies : IEvaluationLoggingDependencies, IInjectableMetadata
{
    private readonly AspectHandler _aspectHandler;

    internal EvaluationLoggingDependencies(AspectHandler aspectHandler) => _aspectHandler = aspectHandler;

    public Microsoft.Extensions.Logging.ILogger Logger => _aspectHandler.ResolveDependency<Microsoft.Extensions.Logging.ILogger>();
}