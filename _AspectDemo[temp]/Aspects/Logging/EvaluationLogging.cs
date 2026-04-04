using AspectEngine;

namespace AspectDemo.Aspects.Logging;


internal readonly partial struct EvaluationLogging : IAspect<int>
{
    private readonly IPseudoLog _logger;

    public void Run(in int context)
    {
        _logger.Log($"Evaluated: {context}");
    }
}