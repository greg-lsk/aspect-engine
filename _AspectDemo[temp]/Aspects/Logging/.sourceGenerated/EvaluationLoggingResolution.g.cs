using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

#nullable enable annotations
internal class EvaluationLoggingResolution : 
    AspectEngine.ProxiedResolution.ProxiedResolutionBase,
    AspectEngine.ProxiedResolution.IResolutionMetadata<EvaluationLogging>
{
    internal AspectEngine.ProxiedResolution.Resolve<AspectDemo.IPseudoLog> LoggerResolution { get; }


    internal EvaluationLoggingResolution(
        AspectEngine.ProxiedResolution.SupplyProvider supplyProvider,
        AspectEngine.ProxiedResolution.Resolve<AspectDemo.IPseudoLog> loggerResolution) : base(supplyProvider)
    {
        LoggerResolution = loggerResolution;
    }


    public SessionOn<EvaluationLogging> CreateSession(SupplyScope? supplyScope = null)
    {
        var a = new EvaluationLogging(this, supplyScope is null ? SupplyRootProvider : () => supplyScope().ServiceProvider);
        return SessionOn<EvaluationLogging>.Create(in a);
    }
}