using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging 
{
    private readonly ResolutionSource _resolutionSource;
    private readonly IResolutionMetadata<EvaluationLogging> _resolutionMetadata;

    private partial IPseudoLog Logger => (_resolutionMetadata as EvaluationLoggingMetadata).LoggerResolution(in _resolutionSource);


    internal EvaluationLogging(in ResolutionSource resolutionSource,
                               IResolutionMetadata<EvaluationLogging> resolutionMetadata)
    {
        _resolutionSource = resolutionSource;
        _resolutionMetadata = resolutionMetadata;
    }
}