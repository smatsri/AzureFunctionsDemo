using Microsoft.Extensions.Configuration;

namespace HelloFunction.Services
{
	public interface IGreeterConfig
	{
		string NoName { get; }
		string WithName { get; }
	}

	public class GreeterConfig : IGreeterConfig
	{
		private readonly IConfiguration configuration;

		public GreeterConfig(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public string NoName => configuration.GetValue<string>("Greeter:NoName");

		public string WithName => configuration.GetValue<string>("Greeter:WithName");
	}
}
