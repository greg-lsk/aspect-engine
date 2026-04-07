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
                       static EvaluationLogging materialize(IResolutionMetadata<EvaluationLogging> metadata,
                                                            in ResolutionSource resolutionSource)
                       {
                           return new(metadata, in resolutionSource);
                       }

                       static T genericResolution<T>(object serviceProvider) where T : notnull
                       {
                           return (serviceProvider as IServiceProvider).GetRequiredService<T>();
                       }

                       static IPseudoLog loggerResolution(in ResolutionSource resolutionSource)
                       {
                           return ResolutionHandler.Create()
                                                   .Execute(genericResolution<IPseudoLog>, in resolutionSource);
                       } 

                       return new(provider, materialize, loggerResolution);
                   });
               })
               .Build();


var resolutionMetadata = host.Services.GetRequiredService<IResolutionMetadata<EvaluationLogging>>();

using (var scope = host.Services.CreateScope())
{
    var i = 15;

    var hostAspect = resolutionMetadata.Materialize();
    var scopeAspect = resolutionMetadata.Materialize(scope);
    
    
    scopeAspect.Run(i++);
    await AsynTask(resolutionMetadata, scope);
    hostAspect.Run(i++); 

    using (var subScope = scope.ServiceProvider.CreateScope())
    {
        var subScopeAspect = resolutionMetadata.Materialize(subScope);

        scopeAspect.Run(i++);
        subScopeAspect.Run(i++);
    }

    scopeAspect.Run(i++);
}

static async Task AsynTask(IResolutionMetadata<EvaluationLogging> metadata, IServiceScope scope)
{
    var aspect = metadata.Materialize(scope);

    await Task.Delay(500);
    aspect.Run(0);
}