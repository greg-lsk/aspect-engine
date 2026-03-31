using AspectEngine;
using AspectEngine.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace AspectDemo.Aspects.Logging;

[Aspect<IEvaluationLogging>]
internal readonly partial struct EvaluationLogging : IEvaluationLogging, IEvaluationLoggingTemplate
{
    public void Run()
    {
        var logger = Services.Logger;

        logger.LogInformation("Evaluated: {data}", Context);
    }
}

internal interface IEvaluationLogging : IAspect { }
internal interface IEvaluationLoggingTemplate : IWithContext<int>, IWithServices<IEvaluationLoggingDependencies> { }