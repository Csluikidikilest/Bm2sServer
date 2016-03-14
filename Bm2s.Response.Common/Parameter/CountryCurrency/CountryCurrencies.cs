using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.CountryCurrency
{
  [Route("/bm2s/countrycurrency", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/countrycurrency/{Ids}", Verbs = "GET")]
  public class CountryCurrencies : Request, IReturn<CountryCurrenciesResponse>
  {
    public CountryCurrencies()
    {
      this.Ids = new List<int>();
    }

    public int CountryId { get; set; }

    public DateTime? Date { get; set; }

    public int UnitId { get; set; }

    public Bm2s.Poco.Common.Parameter.CountryCurrency CountryCurrency { get; set; }
  }
}
