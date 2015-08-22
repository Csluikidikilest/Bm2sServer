using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.Vat
{
  [Route("/bm2s/vats", Verbs = "GET, POST")]
  [Route("/bm2s/vats/{Ids}", Verbs = "GET")]
  public class Vats : IReturn<VatsResponse>
  {
    public Vats()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Poco.Common.Parameter.Vat Vat { get; set; }
  }
}
