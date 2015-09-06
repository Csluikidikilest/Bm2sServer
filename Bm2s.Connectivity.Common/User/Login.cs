using Bm2s.Connectivity.Utils;
using Bm2s.Response;

namespace Bm2s.Connectivity.Common.User
{
  public class Login : ClientBase
  {
    public Login()
      : base()
    {
      this.Request = new Response.Common.User.Login.Login();
      this.Response = new Response.Common.User.Login.LoginResponse();
    }

    public Bm2s.Response.Common.User.Login.Login Request { get; set; }

    public Bm2s.Response.Common.User.Login.LoginResponse Response { get; set; }

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
