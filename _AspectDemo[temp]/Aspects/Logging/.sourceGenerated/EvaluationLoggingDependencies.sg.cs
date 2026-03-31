namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLoggingDependencies
{
    private readonly AspectEngine.DependencyInjection.Resolution _resolution;

    internal EvaluationLoggingDependencies(AspectEngine.DependencyInjection.Resolution resolution) => _resolution = resolution;

    public partial Microsoft.Extensions.Logging.ILogger Logger => _resolution.For<Microsoft.Extensions.Logging.ILogger>();
}