using SlimResolutionCore;


namespace AspectDemo.Aspects.Logging;

internal class EvaluationLoggingMetadata : IResolutionMetadata<EvaluationLogging>
{
    internal Resolution<IPseudoLog> LoggerResolution { get; }


    internal EvaluationLoggingMetadata(
        Resolution<IPseudoLog> loggerResolution)
    {
        LoggerResolution = loggerResolution;
    }


    public EvaluationLogging Materialize(IResolutionContext context)
    {
        return new(this, context);
    }
}