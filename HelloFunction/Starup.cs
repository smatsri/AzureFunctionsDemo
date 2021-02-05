using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using HelloFunction.Services;
using System;

[assembly: FunctionsStartup(typeof(HelloFunction.Startup))]

namespace HelloFunction
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			var isDebug = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Debug";
			builder.Services.AddTransient<IGreeter, Greeater>();
			builder.Services.AddSingleton<IGreeterConfig, GreeterConfig>();
		}
	}
}
