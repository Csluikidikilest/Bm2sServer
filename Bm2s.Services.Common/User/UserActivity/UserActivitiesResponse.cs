using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.User.UserActivity
{
  public class UserActivitiesResponse
  {
    public UserActivitiesResponse()
    {
      this.UserActivities = new List<Bm2s.Poco.Common.User.UserActivity>();
    }

    public List<Bm2s.Poco.Common.User.UserActivity> UserActivities { get; set; }
  }
}
