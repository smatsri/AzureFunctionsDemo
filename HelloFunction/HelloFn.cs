using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HelloFunction.Services;

namespace HelloFunction
{

    public class HelloFn
    {
		private readonly IGreeter greeter;

		public HelloFn(IGreeter greeter)
		{
			this.greeter = greeter;
		}

        [FunctionName("hello")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
			name ??= data?.name;
            var repsonse = greeter.SayHello(name);
            return new OkObjectResult(new { repsonse });

        }
    }
}
