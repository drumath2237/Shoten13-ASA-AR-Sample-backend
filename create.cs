using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Shoten13Sample
{
  public static class create
  {
    [FunctionName("create")]
    public static async Task<IActionResult> Run
    (
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
        HttpRequest req,
        [CosmosDB(
          databaseName:"Anchors",
          collectionName:"Items",
          ConnectionStringSetting = "CosmosDBConnectionString"
        )]
        IAsyncCollector<AnchorInfo> documentOut,
        ILogger log
    )
    {
      string anchorID = req.Query["anchorKey"];
      string expireOn = req.Query["expireOn"];

      if (!string.IsNullOrEmpty(anchorID) && !string.IsNullOrEmpty(expireOn))
      {
        await documentOut.AddAsync(new AnchorInfo
        {
          anchorKey = anchorID,
          expireOn = expireOn
        });

        return new OkResult();
      }

      return new BadRequestResult();
    }
  }
}
