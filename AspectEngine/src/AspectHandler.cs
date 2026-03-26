namespace AspectEngine;

public class AspectHandler
{
    public AspectExecutionEnvironment<TData> CreateEnvironment<TData>(TData data)
    {
        return AspectExecutionEnvironment<TData>.Create(data);
    }
}