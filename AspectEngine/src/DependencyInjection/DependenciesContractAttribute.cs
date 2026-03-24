using System;


namespace AspectEngine.DependencyInjection;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
public class DependenciesContractAttribute : Attribute { }