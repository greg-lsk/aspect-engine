namespace AspectDemo.Aspects.Logging;

internal readonly struct EvaluationLoggingDependencies : IEvaluationLoggingDependencies
{
    private readonly AspectEngine.DependencyInjection.Resolution _resolution;

    internal EvaluationLoggingDependencies(AspectEngine.DependencyInjection.Resolution resolution) => _resolution = resolution;

    public Microsoft.Extensions.Logging.ILogger Logger => _resolution.For<Microsoft.Extensions.Logging.ILogger>();
}