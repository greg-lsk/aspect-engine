namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    internal EvaluationLogging(Func<EvaluationLoggingDependencies> dependenciesFactory) => Dependencies = dependenciesFactory();
    public EvaluationLoggingDependencies Dependencies { get; }
}