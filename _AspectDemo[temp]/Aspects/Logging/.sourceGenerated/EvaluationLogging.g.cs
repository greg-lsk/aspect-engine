namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    private readonly AspectDemo.Aspects.Logging.EvaluationLoggingResolution _evaluationLoggingResolution;
    private readonly AspectEngine.ProxiedResolution.SupplyProvider _supplyProvider;

    private partial AspectDemo.IPseudoLog Logger => _evaluationLoggingResolution.LoggerResolution(_supplyProvider);


    internal EvaluationLogging(
        AspectDemo.Aspects.Logging.EvaluationLoggingResolution evaluationLoggingResolution,
        AspectEngine.ProxiedResolution.SupplyProvider supplyScopedProvider)
    {
        _evaluationLoggingResolution = evaluationLoggingResolution;
        _supplyProvider = supplyScopedProvider;
    }
}