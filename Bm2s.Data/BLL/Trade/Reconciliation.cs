using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Trade
{
  public class Reconciliation
  {
    public double Amount { get; set; }
    public Payment Payment { get; set; }
    public HeaderLine HeaderLine { get; set; }
  }
}
