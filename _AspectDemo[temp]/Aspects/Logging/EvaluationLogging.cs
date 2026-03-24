using AspectEngine;
using AspectEngine.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace AspectDemo.Aspects.Logging;

[Aspect<IEvaluationLogging>]
internal readonly partial struct EvaluationLogging : IEvaluationLogging,
                                                     IAspectOn<int>,
                                                     IInjectWith<EvaluationLoggingDependencies>
{
    public void Run()
    {
        var logger = Dependencies.Logger;

        logger.LogInformation("Evaluated: {data}", Context);
    }
}

internal interface IEvaluationLogging : IAspect { }