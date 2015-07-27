using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.User.UserGroup
{
  [Route("/bm2s/usergroups", Verbs = "GET, POST")]
  [Route("/bm2s/usergroups/{Ids}", Verbs = "GET")]
  public class UserGroups
  {
    public UserGroups()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.User.UserGroup UserGroup { get; set; }
  }
}
