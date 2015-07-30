using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.PaymentMode
{
  [Route("/bm2s/paymentmodes", Verbs = "GET, POST")]
  [Route("/bm2s/paymentmodes/{Ids}", Verbs = "GET")]
  public class PaymentModes : IReturn<PaymentModesResponse>
  {
    public PaymentModes()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.PaymentMode PaymentMode { get; set; }
  }
}
