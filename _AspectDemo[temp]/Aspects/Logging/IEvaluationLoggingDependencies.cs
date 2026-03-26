using Microsoft.Extensions.Logging;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

[DependenciesContract]
public interface IEvaluationLoggingDependencies : IInjectableMetadata
{
    public ILogger Logger { get; }
}