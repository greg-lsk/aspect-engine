namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    public int Context { get; }
    public AspectDemo.Aspects.Logging.EvaluationLoggingDependencies Dependencies { get; }

    internal EvaluationLogging(int context, AspectDemo.Aspects.Logging.EvaluationLoggingDependencies dependencies)
    {
        Context = context;
        Dependencies = dependencies;
    }
}