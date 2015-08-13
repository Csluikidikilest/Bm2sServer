using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.HeaderLineType
{
  [Route("/bm2s/headerlinetypes", Verbs = "GET, POST")]
  [Route("/bm2s/headerlinetypes/{Ids}", Verbs = "GET")]
  public class HeaderLineTypes : IReturn<HeaderLineTypesResponse>
  {
    public HeaderLineTypes()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderLineType HeaderLineType { get; set; }
  }
}
