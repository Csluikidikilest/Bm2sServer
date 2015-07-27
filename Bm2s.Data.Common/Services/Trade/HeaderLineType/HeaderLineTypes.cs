using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderLineType
{
  [Route("/bm2s/headerlinetypes", Verbs = "GET, POST")]
  [Route("/bm2s/headerlinetypes/{Ids}", Verbs = "GET")]
  public class HeaderLineTypes
  {
    public HeaderLineTypes()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.HeaderLineType HeaderLineType { get; set; }
  }
}
