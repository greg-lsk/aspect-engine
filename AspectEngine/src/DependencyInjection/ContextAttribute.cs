using System;


namespace AspectEngine.DependencyInjection;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class ContextAttribute : Attribute { }