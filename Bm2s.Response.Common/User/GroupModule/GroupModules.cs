using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.GroupModule
{
  [Route("/bm2s/groupmodules", Verbs = "GET, POST")]
  [Route("/bm2s/groupmodules/{Ids}", Verbs = "GET")]
  public class GroupModules : IReturn<GroupModulesResponse>
  {
    public GroupModules()
    {
      this.Ids = new List<int>();
    }

    public int GrantorId { get; set; }

    public int GroupId { get; set; }

    public List<int> Ids { get; set; }

    public int ModuleId { get; set; }

    public Bm2s.Poco.Common.User.GroupModule GroupModule { get; set; }
  }
}
