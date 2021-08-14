using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestFunction
{
    public static class TestFunction
    {
        [FunctionName("TestFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "naam/{myname}")] HttpRequest req,
            ILogger log, string myname)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return myname != null
                ? (ActionResult)new OkObjectResult($"Hello,  {myname}")
                : new BadRequestObjectResult("Please pass a name in the query string or in the request bod");
        }
    }
}
