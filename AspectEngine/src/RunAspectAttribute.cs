using System;


namespace AspectEngine;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class RunAspectAttribute<TAspect> : Attribute where TAspect : IAspect { }