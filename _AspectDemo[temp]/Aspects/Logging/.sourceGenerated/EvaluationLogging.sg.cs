namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    internal EvaluationLogging(int context, Microsoft.Extensions.Logging.ILogger logger)
    {
        this._context = context;
        this._logger = logger;
    }
}