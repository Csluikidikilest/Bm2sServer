using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.User.Group;

namespace Bm2s.Connectivity.Common.User
{
  public class Group : ClientBase
  {
    public Group()
      : base()
    {
      this.Request = new Groups();
      this.Response = new GroupsResponse();
    }

    public Groups Request { get; set; }

    public GroupsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
