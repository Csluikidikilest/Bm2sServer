﻿using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.User.UserActivity;

namespace Bm2s.Connectivity.Common.User
{
  public class UserActivity : ClientBase
  {
    public UserActivity()
      : base()
    {
      this.Request = new UserActivities();
      this.Response = new UserActivitiesResponse();
    }

    public UserActivities Request { get; set; }

    public UserActivitiesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
