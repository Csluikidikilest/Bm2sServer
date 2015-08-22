using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.CountryCurrency
{
  [Route("/bm2s/countrycurrency", Verbs = "GET, POST")]
  [Route("/bm2s/countrycurrency/{Ids}", Verbs = "GET")]
  public class CountryCurrencies : IReturn<CountryCurrenciesResponse>
  {
    public CountryCurrencies()
    {
      this.Ids = new List<int>();
    }

    public int CountryId { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public int UnitId { get; set; }

    public Bm2s.Poco.Common.Parameter.CountryCurrency CountryCurrency { get; set; }
  }
}
