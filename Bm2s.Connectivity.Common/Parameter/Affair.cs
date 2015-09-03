using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.Affair;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Affair : ClientBase
  {
    public Affair()
      : base()
    {
      this.Request = new Affairs();
      this.Response = new AffairsResponse();
    }

    public Affairs Request { get; set; }

    public AffairsResponse Response { get; set; }

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
