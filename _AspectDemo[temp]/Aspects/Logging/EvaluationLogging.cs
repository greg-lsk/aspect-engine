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
internal class EvaluationLoggingFactory : IEvaluationLoggingFactory
{
    private readonly Func<ILogger> _loggerResolution;

    internal EvaluationLoggingFactory(Func<ILogger> loggerResolution)
    {
        _loggerResolution = loggerResolution;
    }

    public EvaluationLogging Create(in int context)
    {
        return new(_loggerResolution());
    }
}