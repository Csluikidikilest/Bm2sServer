using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.CountryCurrency
{
  public class CountryCurrenciesResponse
  {
    public CountryCurrenciesResponse()
    {
      this.CountryCurrencies = new List<Bm2s.Data.Common.BLL.Parameter.CountryCurrency>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.CountryCurrency> CountryCurrencies { get; set; }
  }
}
