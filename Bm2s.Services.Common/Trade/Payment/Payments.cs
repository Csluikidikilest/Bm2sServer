using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.Payment
{
  [Route("/bm2s/payments", Verbs = "GET, POST")]
  [Route("/bm2s/payments/{Ids}", Verbs = "GET")]
  public class Payments : IReturn<PaymentsResponse>
  {
    public Payments()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public int PaymentModeId { get; set; }

    public int UnitId { get; set; }

    public Bm2s.Data.Common.BLL.Trade.Payment Payment { get; set; }
  }
}
