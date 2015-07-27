using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.User.GroupModule
{
  [Route("/bm2s/groupmodules", Verbs = "GET, POST")]
  [Route("/bm2s/groupmodules/{Ids}", Verbs = "GET")]
  public class GroupModules
  {
    public GroupModules()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.User.GroupModule GroupModule { get; set; }
  }
}
