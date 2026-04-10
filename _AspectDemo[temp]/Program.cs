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

                   services.AddComposer()
                           .AddResolutionContext();

                   services.AddSingleton<IResolutionMetadata<EvaluationLogging>, EvaluationLoggingMetadata>(provider =>
                   {
                        return new(RegistrationHelper.GenericResolution<IPseudoLog>);
                   });
               })
               .Build();


var aspectComposer = host.Services.GetRequiredService<IComposer<EvaluationLogging>>();

using (var scope = host.Services.CreateScope())
{
    var i = 15;
    var hostAspect = aspectComposer.Compose();
    var scopedAspect = aspectComposer.ComposeFor(scope);

    hostAspect.Run(i++);
    hostAspect.Run(i++);

    scopedAspect.Run(i++);
}