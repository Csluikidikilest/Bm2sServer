using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.Payment
{
  [Route("/bm2s/payments", Verbs = "GET, POST")]
  [Route("/bm2s/payments/{Ids}", Verbs = "GET")]
  public class Payments : IReturn<PaymentsResponse>
  {
    public Payments()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.Payment Payment { get; set; }
  }
}
