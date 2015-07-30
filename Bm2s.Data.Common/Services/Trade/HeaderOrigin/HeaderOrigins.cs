using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderOrigin
{
  [Route("/bm2s/headerorigins", Verbs = "GET, POST")]
  [Route("/bm2s/headerorigins/{Ids}", Verbs = "GET")]
  public class HeaderOrigins : IReturn<HeaderOriginsResponse>
  {
    public HeaderOrigins()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.HeaderOrigin HeaderOrigin { get; set; }
  }
}
