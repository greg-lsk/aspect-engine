using AspectDemo.Aspects.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddSingleton<IEvaluationLoggingFactory, EvaluationLoggingFactory>(provider =>
{
    var loggerResolution = provider.GetRequiredService<ILogger>;
    return new(loggerResolution);
});