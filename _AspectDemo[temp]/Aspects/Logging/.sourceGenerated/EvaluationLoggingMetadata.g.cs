using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal class EvaluationLoggingMetadata : ResolutionMetadata<EvaluationLogging>
{
    internal MetaResolution<IPseudoLog> LoggerResolution { get; }


    internal EvaluationLoggingMetadata(
        object hostingContainer,
        Materialize<EvaluationLogging> materialize,
        MetaResolution<IPseudoLog> loggerResolution) : base(hostingContainer, materialize)
    {
        LoggerResolution = loggerResolution;
    }
}