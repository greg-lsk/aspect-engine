using Microsoft.Extensions.Logging;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

[Injectable]
public interface IEvaluationLoggingDependecies
{
    public ILogger Logger { get; }
}