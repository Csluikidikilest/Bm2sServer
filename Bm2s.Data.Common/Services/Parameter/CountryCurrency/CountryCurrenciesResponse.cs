using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.CountryCurrency
{
  public class CountryCurrenciesResponse
  {
    public CountryCurrenciesResponse()
    {
      this.CountryCurrencies = new List<BLL.Parameter.CountryCurrency>();
    }

    public List<BLL.Parameter.CountryCurrency> CountryCurrencies { get; set; }
  }
}
