using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.Period
{
  [Route("/bm2s/periods", Verbs = "GET, POST")]
  [Route("/bm2s/periods/{Ids}", Verbs = "GET")]
  public class Periods : Request, IReturn<PeriodsResponse>
  {
    public Periods()
    {
      this.Ids = new List<int>();
    }
    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Name { get; set; }

    public int UnitId { get; set; }

    public Bm2s.Poco.Common.Parameter.Period Period { get; set; }
  }
}
