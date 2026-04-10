namespace SlimResolutionCore;

public interface IComposer<T> where T : struct
{
    public T Compose();
}