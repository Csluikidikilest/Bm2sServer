using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  [Alias("Reco")]
  public class Reconciliation : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    [Alias("PaymId")]
    [References(typeof(Payment))]
    public int PaymentId { get; set; }

    [Alias("HeliId")]
    [References(typeof(HeaderLine))]
    public int HeaderLineId { get; set; }
  }
}
