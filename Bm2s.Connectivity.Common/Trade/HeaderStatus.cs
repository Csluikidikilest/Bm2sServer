using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.HeaderStatus;

namespace Bm2s.Connectivity.Common.Trade
{
  public class HeaderStatus : ClientBase
  {
    public HeaderStatus()
      : base()
    {
      this.Request = new HeaderStatuses();
      this.Response = new HeaderStatusesResponse();
    }

    public HeaderStatuses Request { get; set; }

    public HeaderStatusesResponse Response { get; set; }

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
