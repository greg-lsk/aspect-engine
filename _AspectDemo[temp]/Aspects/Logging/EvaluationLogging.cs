using AspectEngine;
using AspectEngine.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace AspectDemo.Aspects.Logging;

[Aspect<IEvaluationLogging>]
internal readonly partial struct EvaluationLogging : IEvaluationLogging
{
    private readonly ILogger _logger;

    [Context]
    private readonly int _context;

    public void Run()
    {
        _logger.LogInformation("Evaluated: {data}", _context);
    }
}

internal interface IEvaluationLogging : IAspect { }


internal interface IEvaluationLoggingFactory : IServiceFactory<int, EvaluationLogging>;
internal class EvaluationLoggingFactory : IEvaluationLoggingFactory
{
    private readonly Func<ILogger> _loggerResolution;

    internal EvaluationLoggingFactory(Func<ILogger> loggerResolution)
    {
        _loggerResolution = loggerResolution;
    }

    public EvaluationLogging Create(in int context)
    {
        return new(context, _loggerResolution());
    }
}