using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.User.UserModule;

namespace Bm2s.Connectivity.Common.User
{
  public class UserModule : ClientBase
  {
    public UserModule()
      : base()
    {
      this.Request = new UserModules();
      this.Response = new UserModulesResponse();
    }

    public UserModules Request { get; set; }

    public UserModulesResponse Response { get; set; }

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

    public void Delete()
    {
      this.Response = this.ConnectorHelper.Delete(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
