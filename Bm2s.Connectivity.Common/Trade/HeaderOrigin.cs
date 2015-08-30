using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.HeaderOrigin;

namespace Bm2s.Connectivity.Common.Trade
{
  public class HeaderOrigin : ClientBase
  {
    public HeaderOrigin()
      : base()
    {
      this.Request = new HeaderOrigins();
      this.Response = new HeaderOriginsResponse();
    }

    public HeaderOrigins Request { get; set; }

    public HeaderOriginsResponse Response { get; set; }

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
