namespace AspectEngine;

public readonly struct AspectExecutionEnvironment<TData>
{
    private readonly TData _data;


    internal static AspectExecutionEnvironment<TData> Create(TData data) => new(data);
    private AspectExecutionEnvironment(TData data)
    {
        _data = data;
    }


    public void Run<TAspect>(TAspect aspect) where TAspect : struct, IAspect
    {
        aspect.Run();
    }
}