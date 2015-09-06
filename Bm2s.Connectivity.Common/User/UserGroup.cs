﻿using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.User.UserGroup;

namespace Bm2s.Connectivity.Common.User
{
  public class UserGroup : ClientBase
  {
    public UserGroup()
      : base()
    {
      this.Request = new UserGroups();
      this.Response = new UserGroupsResponse();
    }

    public UserGroups Request { get; set; }

    public UserGroupsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    public void Post()
    {
      this.Response = this.ConnectorHelper.Post(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}