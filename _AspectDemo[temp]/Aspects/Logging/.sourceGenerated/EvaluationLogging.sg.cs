namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    public int Context { get; }
    public AspectDemo.Aspects.Logging.IEvaluationLoggingDependencies Services { get; }

    internal EvaluationLogging(int context, AspectDemo.Aspects.Logging.IEvaluationLoggingDependencies dependencies)
    {
        Context = context;
        Services = dependencies;
    }
}