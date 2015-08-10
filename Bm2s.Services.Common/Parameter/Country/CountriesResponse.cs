using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Country
{
  public class CountriesResponse
  {
    public CountriesResponse()
    {
      this.Countries = new List<Bm2s.Data.Common.BLL.Parameter.Country>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.Country> Countries { get; set; }
  }
}
