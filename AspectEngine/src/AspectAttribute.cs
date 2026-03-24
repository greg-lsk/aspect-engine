using System;


namespace AspectEngine;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple = false)]
public class AspectAttribute<TAspect> : Attribute where TAspect : IAspect { } 