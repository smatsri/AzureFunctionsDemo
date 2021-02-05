using Microsoft.Extensions.Logging;

namespace HelloFunction.Services
{
	public interface IGreeter
	{
		string SayHello(string name);
	}

	public class Greeater : IGreeter
	{
		private readonly IGreeterConfig config;
		private readonly ILogger<Greeater> logger;

		public Greeater(IGreeterConfig config, ILogger<Greeater> logger)
		{
			this.config = config;
			this.logger = logger;
		}

		public string SayHello(string name)
		{
			logger.LogInformation("Greeater.SayHello was called");
			return string.IsNullOrEmpty(name)
				? config.NoName
				: config.WithName.Replace("{name}", name);
		}
	}
}
