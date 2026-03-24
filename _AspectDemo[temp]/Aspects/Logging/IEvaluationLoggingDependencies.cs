using Microsoft.Extensions.Logging;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

[DependenciesContract]
public interface IEvaluationLoggingDependencies
{
    public ILogger Logger { get; }
}