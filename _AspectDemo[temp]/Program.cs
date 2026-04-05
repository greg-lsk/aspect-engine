using AspectDemo;
using AspectDemo.Aspects.Logging;
using AspectEngine.ProxiedResolution;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddScoped<IPseudoLog, PseudoLog>();

                   services.AddSingleton<IResolutionMetadata<EvaluationLogging>, EvaluationLoggingResolution>(provider =>
                   {
                       IServiceProvider providerSource() => provider;
                       IPseudoLog loggerResolution(SupplyProvider ps) => ps().GetRequiredService<IPseudoLog>();

                       return new(providerSource, loggerResolution);
                   });
               })
               .Build();

var resolution = host.Services.GetRequiredService<IResolutionMetadata<EvaluationLogging>>();

using (var scope = host.Services.CreateScope())
using (var aspectSession = resolution.CreateSession(() => scope))
{
    var i = 15;
    static void runAspect(in EvaluationLogging evaluationLogging, int number) => evaluationLogging.Run(number);
    
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