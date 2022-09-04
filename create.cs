using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Shoten13Sample
{
  public static class create
  {
    [FunctionName("create")]
    public static async Task<IActionResult> Run
    (
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
        HttpRequest req,
        ILogger log
    )
    {
      log.LogInformation(req.Query["name"]);
      return new OkObjectResult("Hello");
    }
  }
}
