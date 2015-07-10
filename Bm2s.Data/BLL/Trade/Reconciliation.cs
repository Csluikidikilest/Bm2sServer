using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class Reconciliation
  {
    public double Amount { get; set; }

    [PrimaryKey]
    [References(typeof(Payment))]
    public int PaymentId { get; set; }

    [ForeignKey("PaymentId")]
    public Payment Payment { get; set; }

    [PrimaryKey]
    [References(typeof(HeaderLine))]
    public int HeaderLineId { get; set; }

    [ForeignKey("HeaderLineId")]
    public HeaderLine HeaderLine { get; set; }
  }
}
