using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.PaymentMode
{
  [Route("/bm2s/paymentmodes", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/paymentmodes/{Ids}", Verbs = "GET")]
  public class PaymentModes : Request, IReturn<PaymentModesResponse>
  {
    public PaymentModes()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Trade.PaymentMode PaymentMode { get; set; }
  }
}
