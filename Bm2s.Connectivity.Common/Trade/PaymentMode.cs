using Bm2s.Connectivity.Utils;
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
  }
}
