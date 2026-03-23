using System;


namespace AspectEngine;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class AspectAttribute<TAspect> : Attribute where TAspect : IAspectMetadata { }