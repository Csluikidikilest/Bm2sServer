using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.Town
{
  [Route("/bm2s/towns", Verbs = "GET, POST")]
  [Route("/bm2s/towns/{Ids}", Verbs = "GET")]
  public class Towns : IReturn<TownsResponse>
  {
    public Towns()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Town Town { get; set; }
  }
}
