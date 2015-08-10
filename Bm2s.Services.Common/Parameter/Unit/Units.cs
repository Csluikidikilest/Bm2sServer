using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.Unit
{
  [Route("/bm2s/units", Verbs = "GET, POST")]
  [Route("/bm2s/units/{Ids}", Verbs = "GET")]
  public class Units : IReturn<UnitsResponse>
  {
    public Units()
    {
      this.Ids = new List<int>();
    }
    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public bool IsCurrency { get; set; }

    public bool IsPeriod { get; set; }

    public string Name { get; set; }

    public Bm2s.Data.Common.BLL.Parameter.Unit Unit { get; set; }
  }
}
