using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.User.UserActivity
{
  public class UserActivitiesResponse
  {
    public UserActivitiesResponse()
    {
      this.UserActivities = new List<BLL.User.UserActivity>();
    }

    public List<BLL.User.UserActivity> UserActivities { get; set; }
  }
}
