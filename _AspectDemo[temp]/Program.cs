using AspectDemo;
using AspectDemo.Aspects.Logging;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using SlimResolutionCore;
using SlimResolutionMcSoftDIExtensions;


var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddScoped<IPseudoLog, PseudoLog>();

                   services.AddComposer()
                           .AddResolutionContext();

                   services.AddSingleton<IResolutionMetadata<EvaluationLogging>, EvaluationLoggingMetadata>(provider =>
                   {
                        return new(RegistrationHelper.GenericResolution<IPseudoLog>);
                   });
               })
               .Build();


var i = 15;
var aspectComposer = host.Services.GetRequiredService<IComposer<EvaluationLogging>>();

var hostAspect = aspectComposer.Compose();
hostAspect.Run(i++);

using (var scope = host.Services.CreateScope())
{
    var scopedAspect = aspectComposer.ComposeFor(scope);

    hostAspect.Run(i++);
    scopedAspect.Run(i++);
}