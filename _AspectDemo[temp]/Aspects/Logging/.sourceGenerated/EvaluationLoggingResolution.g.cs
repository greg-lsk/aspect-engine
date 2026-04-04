namespace AspectDemo.Aspects.Logging;

internal partial class EvaluationLoggingFactory : AspectEngine.ProxiedResolution.ProxiedResolutionBase<EvaluationLogging>
{
    protected override AspectEngine.ProxiedResolution.Resolve<EvaluationLogging> Resolution { get; }


    internal EvaluationLoggingFactory(
        AspectEngine.ProxiedResolution.SupplyProvider supplyProvider,
        AspectEngine.ProxiedResolution.Resolve<AspectDemo.IPseudoLog> loggerResolution) : base(supplyProvider)
    {
        Resolution = sp =>
        {
            return new(loggerResolution(sp));
        };
    }


    public override EvaluationLogging Resolve() => Resolution(SupplyProvider);
}