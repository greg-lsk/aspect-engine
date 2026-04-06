namespace AspectDemo.Aspects.Logging;

internal class EvaluationLoggingMetadata : AspectEngine.ProxiedResolution.IResolutionMetadata<EvaluationLogging>
{
    internal AspectEngine.ProxiedResolution.Resolution LoggerResolution { get; }


    internal EvaluationLoggingMetadata(AspectEngine.ProxiedResolution.Resolution loggerResolution)
    {
        LoggerResolution = loggerResolution;
    }


    public EvaluationLogging Create(in AspectEngine.ProxiedResolution.IResolutionContext<EvaluationLogging> resolutionContext)
    {
        return new(resolutionContext);
    }
}