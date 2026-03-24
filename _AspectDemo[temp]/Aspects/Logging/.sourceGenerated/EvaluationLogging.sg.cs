namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    public int Context { get; }
    public EvaluationLoggingDependencies Dependencies { get; }

    internal EvaluationLogging(EvaluationLoggingDependencies dependencies) => Dependencies = dependencies;
}