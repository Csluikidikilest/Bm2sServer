using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.Country
{
  [Route("/bm2s/country", Verbs = "GET, POST")]
  [Route("/bm2s/country/{Ids}", Verbs = "GET")]
  public class Countries : IReturn<CountriesResponse>
  {
    public Countries()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Parameter.Country Country { get; set; }
}
}
