using Bm2s.Data.BLL.Parameter;
using ServiceStack.DataAnnotations;
using System;

namespace Bm2s.Data.BLL.Trade
{
  public class Payment : Table
  {
    public double Amount { get; set; }

    public DateTime Date { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }

    [References(typeof(PaymentMode))]
    public int PaymentModeId { get; set; }

    [Ignore]
    public PaymentMode PaymentMode { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [Ignore]
    public Unit Unit { get; set; }
  }
}
