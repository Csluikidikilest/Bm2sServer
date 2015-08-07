using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.User.Module
{
  [Route("/bm2s/modules", Verbs = "GET, POST")]
  [Route("/bm2s/modules/{Ids}", Verbs = "GET")]
  public class Modules : IReturn<ModulesResponse>
  {
    public Modules()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public BLL.User.Module Module { get; set; }
  }
}
