using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.UserParameter;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class UserParameter : ClientBase
  {
    public UserParameter()
      : base()
    {
      this.Request = new UserParameters();
      this.Response = new UserParametersResponse();
    }

    public UserParameters Request { get; set; }

    public UserParametersResponse Response { get; set; }

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
