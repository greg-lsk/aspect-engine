using System;


namespace AspectEngine.ProxiedResolution;

[AttributeUsage(AttributeTargets.Struct)]
public class ResolveViaAttribute<T> : Attribute
{
    public string DeclaredNamespace => typeof(T).Namespace;
    public string ConcreteImplementationName => typeof(T).Name;
}