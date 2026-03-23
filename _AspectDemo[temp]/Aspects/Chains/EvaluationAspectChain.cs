using AspectEngine;
using AspectDemo.Aspects.Logging;


namespace AspectDemo.Aspects.Chains;

internal readonly partial struct EvaluationAspectChain : IAspectChain<int>
{
    [Aspect<IEvaluationLogging>]
    public partial void Run(in int data);
}


internal readonly partial struct EvaluationAspectChain
{    
    public partial void Run(in int data) => AspectChain.For(data)
                                                       .Run(s => new EvaluationLogging(new EvaluationLoggingDependencies(s)));
}