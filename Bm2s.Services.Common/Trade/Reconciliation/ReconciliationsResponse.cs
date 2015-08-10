using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.Reconciliation
{
  public class ReconciliationsResponse
  {
    public ReconciliationsResponse()
    {
      this.Reconciliations = new List<Bm2s.Data.Common.BLL.Trade.Reconciliation>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.Reconciliation> Reconciliations { get; set; }
  }
}
