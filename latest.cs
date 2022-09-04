using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Shoten13Sample
{
  public static class latest
  {
    [FunctionName("latest")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
        HttpRequest req,
        [CosmosDB(
            databaseName:"Anchors",
            collectionName:"Items",
            ConnectionStringSetting ="CosmosDBConnectionString",
            SqlQuery ="SELECT top 1 c.anchorKey,c.expireOn From c order by c._ts desc"
        )]
        IEnumerable<AnchorInfo> anchorInfos,
        ILogger log)
    {
      var anchorInfo = anchorInfos.FirstOrDefault();
      return new OkObjectResult(anchorInfo);
    }
  }
}
