using System;
using Microsoft.Extensions.DependencyInjection;


namespace AspectEngine.ProxiedResolution;

public delegate IServiceScope CreateScope();
public delegate IServiceProvider SupplyProvider();
public delegate T Resolve<T>(SupplyProvider supplyProvider);