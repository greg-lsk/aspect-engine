using AspectEngine;
using AspectEngine.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging : IAspect<int>
{
    private readonly ILogger _logger;

    public void Run(in int context)
    {
        _logger.LogInformation("Evaluated: {context}", context);
    }
}

internal interface IEvaluationLoggingFactory : IProxiedResolution<EvaluationLogging>;
internal partial class EvaluationLoggingFactory : IEvaluationLoggingFactory { }


internal partial class EvaluationLoggingFactory : ProxiedResolutionBase<EvaluationLogging>
{
    private readonly Resolve<ILogger> _loggerResolution;
    protected override Resolve<EvaluationLogging> Resolve { get; }


    internal EvaluationLoggingFactory(CreateScope createScope,
                                      SupplyProvider supplyProvider,
                                      Resolve<ILogger> loggerResolution) : base(createScope, supplyProvider)
    {
        _loggerResolution = loggerResolution;

        Resolve = sp =>
        {
            return new(_loggerResolution(sp));
        };
    }

    public override EvaluationLogging Create() => Resolve(SupplyProvider);
}