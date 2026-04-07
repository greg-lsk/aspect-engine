using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal class EvaluationLoggingMetadata : ResolutionMetadata<EvaluationLogging>
{
    internal MetaResolution<IPseudoLog> LoggerResolution { get; }


    internal EvaluationLoggingMetadata(
        object hostingContainer,
        MetaResolution<IPseudoLog> loggerResolution) : base(hostingContainer)
    {
        LoggerResolution = loggerResolution;
    }


    public override EvaluationLogging Materialize(IResolutionMetadata<EvaluationLogging> resolutionMetadata,
                                                  in ResolutionSource resolutionSource)
    {
        return new(in resolutionSource, resolutionMetadata);
    }
}