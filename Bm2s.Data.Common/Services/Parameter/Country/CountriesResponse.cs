using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Country
{
  public class CountriesResponse
  {
    public CountriesResponse()
    {
      this.Countries = new List<BLL.Parameter.Country>();
    }

    public List<BLL.Parameter.Country> Countries { get; set; }
  }
}
