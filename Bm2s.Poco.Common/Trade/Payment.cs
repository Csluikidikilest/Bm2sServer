using System;
using Bm2s.Poco.Common.Parameter;

namespace Bm2s.Poco.Common.Trade
{
  public class Payment
  {
    public int Id { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public Partner.Partner Partner { get; set; }

    public PaymentMode PaymentMode { get; set; }

    public Unit Unit { get; set; }
  }
}
