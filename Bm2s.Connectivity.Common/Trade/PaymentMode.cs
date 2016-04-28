using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.PaymentMode;

namespace Bm2s.Connectivity.Common.Trade
{
  public class PaymentMode : ClientBase
  {
    public PaymentMode()
      : base()
    {
      this.Request = new PaymentModes();
      this.Response = new PaymentModesResponse();
    }

    public PaymentModes Request { get; set; }

    public PaymentModesResponse Response { get; set; }

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
