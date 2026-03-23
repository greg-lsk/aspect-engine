using Microsoft.Extensions.Logging;

using AspectEngine;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

[Injectee]
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

internal interface IEvaluationLogging : IAspectMetadata { }