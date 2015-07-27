using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderFile
{
  [Route("/bm2s/headerfiles", Verbs = "GET, POST")]
  [Route("/bm2s/headerfiles/{Ids}", Verbs = "GET")]
  public class HeaderFiles
  {
    public HeaderFiles()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.HeaderFile HeaderFile { get; set; }
  }
}
