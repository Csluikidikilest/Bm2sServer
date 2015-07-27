using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.Affair
{
  [Route("/bm2s/affairs", Verbs = "GET, POST")]
  [Route("/bm2s/affairs/{Ids}", Verbs = "GET")]
  public class Affairs : IReturn<AffairsResponse>
  {
    public Affairs()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Affair Affair { get; set; }
  }
}
