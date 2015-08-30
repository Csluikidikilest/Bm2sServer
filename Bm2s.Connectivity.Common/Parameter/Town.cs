using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.Town;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Town : ClientBase
  {
    public Town()
      : base()
    {
      this.Request = new Towns();
      this.Response = new TownsResponse();
    }

    public Towns Request { get; set; }

    public TownsResponse Response { get; set; }

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
