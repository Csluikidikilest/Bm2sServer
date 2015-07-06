using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Sell
{
  public class Reconciliation
  {
    public decimal Amount { get; set; }
    public Payment Payment { get; set; }
    public HeaderLine HeaderLine { get; set; }
  }
}
