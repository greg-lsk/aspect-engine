using AspectEngine;
using AspectDemo.Aspects.Logging;


namespace AspectDemo.Aspects.Chains;

internal readonly partial struct EvaluationAspectChain : IAspectChain<int>
{
    //[RunAspect<IEvaluationLogging>]
    public partial void Run(in int data);
}