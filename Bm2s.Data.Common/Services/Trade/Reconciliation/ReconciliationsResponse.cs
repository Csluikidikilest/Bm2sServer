using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.Reconciliation
{
  public class ReconciliationsResponse
  {
    public ReconciliationsResponse()
    {
      this.Reconciliations = new List<BLL.Trade.Reconciliation>();
    }

    public List<BLL.Trade.Reconciliation> Reconciliations { get; set; }
  }
}
