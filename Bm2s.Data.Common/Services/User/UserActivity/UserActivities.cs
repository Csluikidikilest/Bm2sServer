using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.User.UserActivity
{
  [Route("/bm2s/useractivities", Verbs = "GET, POST")]
  [Route("/bm2s/useractivities/{Ids}", Verbs = "GET")]
  public class UserActivities : IReturn<UserActivitiesResponse>
  {
    public UserActivities()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.User.UserActivity UserActivity { get; set; }
  }
}
