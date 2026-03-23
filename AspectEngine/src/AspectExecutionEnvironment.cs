using System;


namespace AspectEngine;

public readonly struct AspectExecutionEnvironment<TData>
{
    private readonly TData _data;
    private readonly IServiceProvider _serviceProvider;


    internal static AspectExecutionEnvironment<TData> Create(TData data, IServiceProvider serviceProvider) => new(data, serviceProvider);
    private AspectExecutionEnvironment(TData data, IServiceProvider serviceProvider)
    {
        _data = data;
        _serviceProvider = serviceProvider;
    }


    public AspectExecutionEnvironment<TData> Run<TAspect>() where TAspect : struct, IAspectMetadata
    {
        //TODO:: need to find a way to get the [Injectable] from the [Injectee]/Apect<>/AspectMetadata

        //Create Injectable
        //Create Aspect
        //Run Aspect

        return this;
    }
}