using AspectEngine.ProxiedResolution;


namespace AspectDemo.Aspects.Logging;

internal interface IEvaluationLoggingFactory : IProxiedResolution<EvaluationLogging>;
internal partial class EvaluationLoggingFactory : IEvaluationLoggingFactory { }