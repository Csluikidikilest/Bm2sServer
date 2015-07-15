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
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public double Amount { get; set; }

    [References(typeof(Payment))]
    public int PaymentId { get; set; }

    [References(typeof(HeaderLine))]
    public int HeaderLineId { get; set; }
  }
}
