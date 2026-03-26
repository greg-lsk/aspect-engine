using Microsoft.Extensions.Logging;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

[ServicesContract]
public interface IEvaluationLoggingDependencies : IServicesMetadata
{
    public ILogger Logger { get; }
}