using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging 
{
    private readonly IResolutionMetadata<EvaluationLogging> _resolutionMetadata;
    private readonly IResolutionMetadataHandler _resolutionMetadataHandler;


    private partial IPseudoLog Logger 
        => _resolutionMetadataHandler.Execute((_resolutionMetadata as EvaluationLoggingMetadata).LoggerResolution);


    internal EvaluationLogging(IResolutionMetadata<EvaluationLogging> resolutionMetadata,
                               IResolutionMetadataHandler resolutionMetadataHandler)
    {
        _resolutionMetadata = resolutionMetadata;
        _resolutionMetadataHandler = resolutionMetadataHandler;
    }
}