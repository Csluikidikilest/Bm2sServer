using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderFile
{
  [Route("/bm2s/headerfiles", Verbs = "GET, POST")]
  [Route("/bm2s/headerfiles/{Ids}", Verbs = "GET")]
  public class HeaderFiles : IReturn<HeaderFilesResponse>
  {
    public HeaderFiles()
    {
      this.Ids = new List<int>();
    }

    public DateTime? AddingDate { get; set; }

    public int HeaderId { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public int UserId { get; set; }

    public BLL.Trade.HeaderFile HeaderFile { get; set; }
  }
}
