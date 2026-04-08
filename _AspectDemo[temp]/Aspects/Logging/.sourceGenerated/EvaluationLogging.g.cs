using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging 
{
    private readonly ResolutionSource _resolutionSource;
    private readonly IResolutionMetadata<EvaluationLogging> _resolutionMetadata;

    private partial IPseudoLog Logger => (_resolutionMetadata as EvaluationLoggingMetadata).LoggerResolution(in _resolutionSource);


    internal EvaluationLogging(object resolutionSource,
                               IResolutionMetadata<EvaluationLogging> resolutionMetadata,
                               IResolutionMetadataUtills resolutionMetadataUtills)
    {
        _resolutionSource = resolutionMetadataUtills.CreateResolutionSource<EvaluationLogging>(resolutionMetadata, resolutionSource);
        _resolutionMetadata = resolutionMetadata;
    }
}