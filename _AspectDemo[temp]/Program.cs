using AspectDemo;
using AspectDemo.Aspects.Logging;
using AspectEngine.ProxiedResolution;
using AspectEngine.ProxiedResolution.IResolutionContextExtensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddScoped<IPseudoLog, PseudoLog>();

                   services.AddSingleton<IResolutionMetadata<EvaluationLogging>, EvaluationLoggingMetadata>(provider =>
                   {
                       static object loggerResolution(object serviceProvider) => (serviceProvider as IServiceProvider).GetRequiredService<IPseudoLog>();

                       return new(loggerResolution);
                   });
               })
               .Build();


var resolution = host.Services.GetRequiredService<IResolutionMetadata<EvaluationLogging>>();

using (var scope = host.Services.CreateScope())
using (var aspectSession = SessionOn<IResolution<EvaluationLogging>>.Create(resolution.CreateContext(scope)))
{
    var i = 15;
    static void runAspect(in IResolution<EvaluationLogging> aspectResolution, int number) => aspectResolution.Result.Run(number);

    aspectSession.Execute(runAspect, i++);
    aspectSession.Execute(runAspect, i++);
    aspectSession.Execute(runAspect, i++);

    using (var subScope = scope.ServiceProvider.CreateScope())
    using (var subScopedHost = resolution.CreateSession(() => subScope))
    {
        aspectSession.Execute(runAspect, i++);
        subScopedHost.Execute(runAspect, i++);
    }

    aspectSession.Execute(runAspect, i++);
}