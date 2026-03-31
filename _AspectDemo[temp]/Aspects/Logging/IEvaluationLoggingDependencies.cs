using Microsoft.Extensions.Logging;
using AspectEngine.DependencyInjection;


namespace AspectDemo.Aspects.Logging;

public interface IEvaluationLoggingDependencies : IServicesMetadata
{
    public ILogger Logger { get; }
}


[ServicesContract] 
internal readonly partial struct EvaluationLoggingDependencies : IEvaluationLoggingDependencies
{
    public partial ILogger Logger { get; }
}