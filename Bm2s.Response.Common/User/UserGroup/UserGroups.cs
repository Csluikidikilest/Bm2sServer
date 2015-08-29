using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.UserGroup
{
  [Route("/bm2s/usergroups", Verbs = "GET, POST")]
  [Route("/bm2s/usergroups/{Ids}", Verbs = "GET")]
  public class UserGroups : Request, IReturn<UserGroupsResponse>
  {
    public UserGroups()
    {
      this.Ids = new List<int>();
    }

    public int GroupId { get; set; }

    public int UserId { get; set; }

    public Bm2s.Poco.Common.User.UserGroup UserGroup { get; set; }
  }
}
