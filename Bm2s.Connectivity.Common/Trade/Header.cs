using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.Header;

namespace Bm2s.Connectivity.Common.Trade
{
  public class Header : ClientBase
  {
    public Header()
      : base()
    {
      this.Request = new Headers();
      this.Response = new HeadersResponse();
    }

    public Headers Request { get; set; }

    public HeadersResponse Response { get; set; }

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
