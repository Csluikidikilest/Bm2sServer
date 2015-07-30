using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.Country
{
  [Route("/bm2s/country", Verbs = "GET, POST")]
  [Route("/bm2s/country/{Ids}", Verbs = "GET")]
  public class Countries : IReturn<CountriesResponse>
  {
    public Countries()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Country Country { get; set; }
}
}
