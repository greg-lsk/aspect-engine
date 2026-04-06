using AspectDemo;
using AspectDemo.Aspects.Logging;

using AspectEngine.ProxiedResolution;
using AspectEngine.ProxiedResolution.Extensions.MicrosoftDependencyInjection;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddScoped<IPseudoLog, PseudoLog>();

                   services.AddSingleton<IResolutionMetadata<EvaluationLogging>, EvaluationLoggingMetadata>(provider =>
                   {
                       static object loggerResolution(object serviceProvider)
                       {
                           return (serviceProvider as IServiceProvider).GetRequiredService<IPseudoLog>();
                       } 

                       return new(loggerResolution);
                   });
               })
               .Build();


var resolutionMetadata = host.Services.GetRequiredService<IResolutionMetadata<EvaluationLogging>>();

using (var scope = host.Services.CreateScope())
using (var aspect = resolutionMetadata.Materialize(scope))
{
    var i = 15;

    aspect.Run(i++);
    aspect.Run(i++); 

    using (var subScope = scope.ServiceProvider.CreateScope())
    using (var subScopedAspect = resolutionMetadata.Materialize(subScope))
    {
        aspect.Run(i++);
        subScopedAspect.Run(i++);
    }

    aspect.Run(i++);
}