using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal class EvaluationLoggingMetadata : IResolutionMetadata<EvaluationLogging>
{
    internal ServiceResolution<IPseudoLog> LoggerResolution { get; }


    internal EvaluationLoggingMetadata(
        ServiceResolution<IPseudoLog> loggerResolution)
    {
        LoggerResolution = loggerResolution;
    }


    public EvaluationLogging Materialize(IResolutionContext context)
    {
        return new(this, context);
    }
}