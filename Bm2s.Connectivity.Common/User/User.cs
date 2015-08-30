using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.User.User;

namespace Bm2s.Connectivity.Common.User
{
  public class User : ClientBase
  {
    public User()
      : base()
    {
      this.Request = new Users();
      this.Response = new UsersResponse();
    }

    public Users Request { get; set; }

    public UsersResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
