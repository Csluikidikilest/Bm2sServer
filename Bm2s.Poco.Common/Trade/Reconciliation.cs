using System;

namespace Bm2s.Poco.Common.Trade
{
  public class Reconciliation
  {
    public int Id { get; set; }

    public double Amount { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Payment Payment { get; set; }

    public HeaderLine HeaderLine { get; set; }
  }
}
