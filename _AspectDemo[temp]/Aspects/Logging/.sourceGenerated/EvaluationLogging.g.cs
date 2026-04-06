using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging : ISessionColleague<EvaluationLogging>
{
    private readonly IResolutionContext<EvaluationLogging> _aspectContext;
    IResolutionContext<EvaluationLogging> ISessionColleague<EvaluationLogging>.ResolutionContext => _aspectContext;

    private partial AspectDemo.IPseudoLog Logger => _aspectContext.Run((_aspectContext.ResolutionMetadata as EvaluationLoggingMetadata).LoggerResolution);


    internal EvaluationLogging(IResolutionContext<EvaluationLogging> aspectContext)
    {
        _aspectContext = aspectContext;
    }
}