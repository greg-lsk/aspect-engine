namespace AspectDemo.Aspects.Logging;

internal readonly partial struct EvaluationLogging
{
    internal EvaluationLogging(AspectDemo.IPseudoLog logger)
    {
        this._logger = logger;
    }
}