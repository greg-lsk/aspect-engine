namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging 
    : AspectEngine.ProxiedResolution.IResolutionContextHolder<EvaluationLogging>
{
    private readonly AspectEngine.ProxiedResolution.IResolutionContext<EvaluationLogging> _aspectContext;
    AspectEngine.ProxiedResolution.IResolutionContext<EvaluationLogging> AspectEngine.ProxiedResolution.IResolutionContextHolder<EvaluationLogging>.ResolutionContext
        => _aspectContext;

    private partial AspectDemo.IPseudoLog Logger => (AspectDemo.IPseudoLog) _aspectContext.Run((_aspectContext.ResolutionMetadata as EvaluationLoggingMetadata).LoggerResolution);

    internal EvaluationLogging(AspectEngine.ProxiedResolution.IResolutionContext<EvaluationLogging> aspectContext)
    {
        _aspectContext = aspectContext;
    }
}