using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.UserActivity
{
  [Route("/bm2s/useractivities", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/useractivities/{Ids}", Verbs = "GET")]
  public class UserActivities : Request, IReturn<UserActivitiesResponse>
  {
    public UserActivities()
    {
      this.Ids = new List<int>();
    }

    public int ActivityId { get; set; }

    public int UserId { get; set; }

    public Bm2s.Poco.Common.User.UserActivity UserActivity { get; set; }
  }
}
