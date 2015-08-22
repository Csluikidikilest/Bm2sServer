using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Country
{
  public class CountriesResponse
  {
    public CountriesResponse()
    {
      this.Countries = new List<Bm2s.Poco.Common.Parameter.Country>();
    }

    public List<Bm2s.Poco.Common.Parameter.Country> Countries { get; set; }
  }
}
