using System;


namespace AspectEngine.DependencyInjection;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple = false)]
public class ServicesContractAttribute : Attribute { }