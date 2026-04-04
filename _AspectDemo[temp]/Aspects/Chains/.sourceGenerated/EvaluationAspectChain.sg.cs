namespace AspectDemo.Aspects.Chains;

internal readonly partial struct EvaluationAspectChain
{
    private readonly AspectEngine.AspectHandler _aspectHandler;

    public partial void Run(in int data)
    {
        //var executionEnvironment = _aspectHandler.CreateEnvironment(data);

        //executionEnvironment.Run(new AspectDemo.Aspects.Logging.EvaluationLogging(data, new AspectDemo.Aspects.Logging.EvaluationLoggingDependencies(_aspectHandler)));
    }
}