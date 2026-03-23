using Microsoft.Extensions.Logging;

using AspectEngine;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

[Injectee]
internal readonly partial struct EvaluationLogging : IAspect<int>,
                                                     IInjectWith<EvaluationLoggingDependencies>
{
    public void Run(in int data)
    {
        var logger = Dependencies.Logger;

        logger.LogInformation("Evaluated: {data}", data);
    }
}