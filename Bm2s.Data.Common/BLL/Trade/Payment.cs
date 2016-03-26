using System;
using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Payment : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public string Reference { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [References(typeof(PaymentMode))]
    public int PaymentModeId { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}
