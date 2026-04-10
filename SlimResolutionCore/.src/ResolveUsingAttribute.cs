using System;


namespace SlimResolutionCore;

[AttributeUsage(AttributeTargets.Struct)]
public class ResolveUsingAttribute<T> : Attribute
{
    public string DeclaredNamespace => typeof(T).Namespace;
    public string ConcreteImplementationName => typeof(T).Name;
}