using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.Reconciliation
{
  [Route("/bm2s/reconciliations", Verbs = "GET, POST")]
  [Route("/bm2s/reconciliations/{Ids}", Verbs = "GET")]
  public class Reconciliations : IReturn<ReconciliationsResponse>
  {
    public Reconciliations()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.Reconciliation Reconciliation { get; set; }
  }
}
