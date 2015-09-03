using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.Payment;

namespace Bm2s.Connectivity.Common.Trade
{
  public class Payment : ClientBase
  {
    public Payment()
      : base()
    {
      this.Request = new Payments();
      this.Response = new PaymentsResponse();
    }

    public Payments Request { get; set; }

    public PaymentsResponse Response { get; set; }

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
