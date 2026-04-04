using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using AspectDemo;
using AspectDemo.Aspects.Logging;
using AspectEngine.ProxiedResolution;

var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddScoped<IPseudoLog, PseudoLog>();

                   services.AddSingleton<IEvaluationLoggingFactory, EvaluationLoggingFactory>(provider =>
                   {
                       IServiceProvider providerSource() => provider;
                       IPseudoLog loggerResolution(SupplyProvider ps) => ps().GetRequiredService<IPseudoLog>();

                       return new(providerSource, loggerResolution);
                   });
               })
               .Build();


using (var scope = host.Services.CreateScope())
{
    var i = 15;
    var scopedProvider = scope.ServiceProvider;
    var resolution = scopedProvider.GetRequiredService<IEvaluationLoggingFactory>();
    
    var aspect = resolution.Resolve();
    aspect.Run(i++);

    aspect = resolution.Resolve();
    aspect.Run(i++);
    aspect.Run(i++);

    using (var subScope = scopedProvider.CreateScope())
    using (var scopedResolution = resolution.AsScoped(() => subScope))
    {
        aspect = scopedResolution.Resolve();
        aspect.Run(i++);
    }

    //possible leak...
    aspect.Run(i++);
}