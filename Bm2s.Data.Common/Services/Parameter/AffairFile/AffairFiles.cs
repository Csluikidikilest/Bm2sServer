using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.AffairFile
{
  [Route("/bm2s/affairfiles", Verbs = "GET, POST")]
  [Route("/bm2s/affairfiles/{Ids}", Verbs = "GET")]
  public class AffairFiles : IReturn<AffairFilesResponse>
  {
    public AffairFiles()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.AffairFile AffairFile { get; set; }
  }
}
