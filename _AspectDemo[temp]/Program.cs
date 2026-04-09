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

                   services.AddResolution()
                           .AddResolutionMetadataHandler();

                   services.AddSingleton<IResolutionMetadata<EvaluationLogging>, EvaluationLoggingMetadata>(provider =>
                   {
                       static T genericResolution<T>(object serviceProvider) where T : notnull
                       {
                           return (serviceProvider as IServiceProvider).GetRequiredService<T>();
                       }

                       return new(genericResolution<IPseudoLog>);
                   });
               })
               .Build();


var aspectResolution = host.Services.GetRequiredService<IResolution<EvaluationLogging>>();

using (var scope = host.Services.CreateScope())
{
    var i = 15;
    var hostAspect = aspectResolution.Invoke();

    hostAspect.Run(i++);
    hostAspect.Run(i++);
}