namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    internal EvaluationLogging(Microsoft.Extensions.Logging.ILogger logger)
    {
        this._logger = logger;
    }
}