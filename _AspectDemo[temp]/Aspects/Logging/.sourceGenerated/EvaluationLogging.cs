namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    public EvaluationLoggingDependencies Dependencies { get; }

    internal EvaluationLogging(Func<EvaluationLoggingDependencies> dependenciesFactory) => Dependencies = dependenciesFactory();
}