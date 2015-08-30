using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.User.Module;

namespace Bm2s.Connectivity.Common.User
{
  public class Module : ClientBase
  {
    public Module()
      : base()
    {
      this.Request = new Modules();
      this.Response = new ModulesResponse();
    }

    public Modules Request { get; set; }

    public ModulesResponse Response { get; set; }

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
