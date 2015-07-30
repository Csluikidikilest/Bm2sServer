using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.Unit
{
  [Route("/bm2s/units", Verbs = "GET, POST")]
  [Route("/bm2s/units/{Ids}", Verbs = "GET")]
  public class Units : IReturn<UnitsResponse>
  {
    public Units()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Unit Unit { get; set; }
  }
}
