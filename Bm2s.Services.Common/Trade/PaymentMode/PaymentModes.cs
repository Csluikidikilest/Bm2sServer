using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.PaymentMode
{
  [Route("/bm2s/paymentmodes", Verbs = "GET, POST")]
  [Route("/bm2s/paymentmodes/{Ids}", Verbs = "GET")]
  public class PaymentModes : IReturn<PaymentModesResponse>
  {
    public PaymentModes()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Trade.PaymentMode PaymentMode { get; set; }
  }
}
