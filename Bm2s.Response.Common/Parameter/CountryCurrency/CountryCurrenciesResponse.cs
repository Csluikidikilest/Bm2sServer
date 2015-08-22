using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.CountryCurrency
{
  public class CountryCurrenciesResponse
  {
    public CountryCurrenciesResponse()
    {
      this.CountryCurrencies = new List<Bm2s.Poco.Common.Parameter.CountryCurrency>();
    }

    public List<Bm2s.Poco.Common.Parameter.CountryCurrency> CountryCurrencies { get; set; }
  }
}
