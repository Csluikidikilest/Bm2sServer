using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.User.UserGroup
{
  [Route("/bm2s/usergroups", Verbs = "GET, POST")]
  [Route("/bm2s/usergroups/{Ids}", Verbs = "GET")]
  public class UserGroups : IReturn<UserGroupsResponse>
  {
    public UserGroups()
    {
      this.Ids = new List<int>();
    }

    public int GroupId { get; set; }

    public List<int> Ids { get; set; }

    public int UserId { get; set; }

    public Bm2s.Data.Common.BLL.User.UserGroup UserGroup { get; set; }
  }
}
