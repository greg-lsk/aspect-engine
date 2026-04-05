using AspectEngine;
using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

[ResolveUsing<IResolutionMetadata<EvaluationLogging>>]
internal readonly partial struct EvaluationLogging : IAspect<int>
{
    private partial IPseudoLog Logger { get; }

    public void Run(in int context)
    {
        Logger.Log($"Evaluated: {context}");
    }
}