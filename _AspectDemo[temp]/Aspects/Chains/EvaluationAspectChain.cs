using AspectEngine;
using AspectDemo.Aspects.Logging;


namespace AspectDemo.Aspects.Chains;

internal readonly struct EvaluationAspectChain : IAspectChain<int>
{
    public void Run(in int data) => AspectChain.For(data)
                                               .Run<EvaluationLogging>();
}