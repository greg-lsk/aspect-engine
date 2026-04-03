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

internal interface IEvaluationLoggingFactory : IProxiedResolution<int, EvaluationLogging>;
internal partial class EvaluationLoggingFactory : IEvaluationLoggingFactory { }


internal partial class EvaluationLoggingFactory : ProxiedResolutionBase
{
    private readonly Func<ProviderSource, ILogger> _loggerResolution;

    internal EvaluationLoggingFactory(ScopeFactory scopeFactory,
                                      ProviderSource providerSource,
                                      Func<ProviderSource, ILogger> loggerResolution) : base(scopeFactory, providerSource)
    {
        _loggerResolution = loggerResolution;
    }
    
    public EvaluationLogging Create()
    {
        return new(_loggerResolution(_providerSource));
    }

    public Wrap<int, EvaluationLogging, IProxiedResolution<int, EvaluationLogging>> AsScoped()
    {
        var scope = _scopeFactory();

        var factory = new EvaluationLoggingFactory(_scopeFactory, () => _scopeFactory().ServiceProvider, _loggerResolution);

        return new(scope, factory);
    }
}