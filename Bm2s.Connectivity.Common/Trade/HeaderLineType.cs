using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.HeaderLineType;

namespace Bm2s.Connectivity.Common.Trade
{
  public class HeaderLineType : ClientBase
  {
    public HeaderLineType()
      : base()
    {
      this.Request = new HeaderLineTypes();
      this.Response = new HeaderLineTypesResponse();
    }

    public HeaderLineTypes Request { get; set; }

    public HeaderLineTypesResponse Response { get; set; }

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
