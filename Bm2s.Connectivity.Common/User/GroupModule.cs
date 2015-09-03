using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.User.GroupModule;

namespace Bm2s.Connectivity.Common.User
{
  public class GroupModule : ClientBase
  {
    public GroupModule()
      : base()
    {
      this.Request = new GroupModules();
      this.Response = new GroupModulesResponse();
    }

    public GroupModules Request { get; set; }

    public GroupModulesResponse Response { get; set; }

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
