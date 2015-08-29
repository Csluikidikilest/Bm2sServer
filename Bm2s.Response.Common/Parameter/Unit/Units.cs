using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.Unit
{
  [Route("/bm2s/units", Verbs = "GET, POST")]
  [Route("/bm2s/units/{Ids}", Verbs = "GET")]
  public class Units : Request, IReturn<UnitsResponse>
  {
    public Units()
    {
      this.Ids = new List<int>();
    }
    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public bool IsCurrency { get; set; }

    public bool IsPeriod { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Parameter.Unit Unit { get; set; }
  }
}
