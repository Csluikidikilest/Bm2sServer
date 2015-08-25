using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Trade.Reconciliation;

namespace Bm2s.Connectivity.Common.Trade
{
  public class Reconciliation : ClientBase
  {
    public Reconciliation()
      : base()
    {
      this.Request = new Reconciliations();
      this.Response = new ReconciliationsResponse();
    }

    public Reconciliations Request { get; set; }

    public ReconciliationsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
