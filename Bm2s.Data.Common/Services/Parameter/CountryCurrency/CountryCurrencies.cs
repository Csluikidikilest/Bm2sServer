using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.CountryCurrency
{
  [Route("/bm2s/countrycurrency", Verbs = "GET, POST")]
  [Route("/bm2s/countrycurrency/{Ids}", Verbs = "GET")]
  public class CountryCurrencies : IReturn<CountryCurrenciesResponse>
  {
    public CountryCurrencies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.CountryCurrency CountryCurrency { get; set; }
  }
}
