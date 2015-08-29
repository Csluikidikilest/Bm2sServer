using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.Reconciliation
{
  [Route("/bm2s/reconciliations", Verbs = "GET, POST")]
  [Route("/bm2s/reconciliations/{Ids}", Verbs = "GET")]
  public class Reconciliations : Request, IReturn<ReconciliationsResponse>
  {
    public Reconciliations()
    {
      this.Ids = new List<int>();
    }

    public int HeaderLineId { get; set; }

    public int PaymentId { get; set; }

    public Bm2s.Poco.Common.Trade.Reconciliation Reconciliation { get; set; }
  }
}
