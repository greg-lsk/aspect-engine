using Microsoft.Extensions.Logging;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

[Injectable]
public interface IEvaluationLoggingDependencies
{
    public ILogger Logger { get; }
}