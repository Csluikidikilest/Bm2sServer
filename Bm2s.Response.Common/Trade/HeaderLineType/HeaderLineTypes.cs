using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.HeaderLineType
{
  [Route("/bm2s/headerlinetypes", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/headerlinetypes/{Ids}", Verbs = "GET")]
  public class HeaderLineTypes : Request, IReturn<HeaderLineTypesResponse>
  {
    public HeaderLineTypes()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderLineType HeaderLineType { get; set; }
  }
}
