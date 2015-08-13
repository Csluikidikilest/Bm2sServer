
namespace Bm2s.Poco.Common.Trade
{
  public class Reconciliation
  {
    public int Id { get; set; }

    public double Amount { get; set; }

    public Payment Payment { get; set; }

    public HeaderLine HeaderLine { get; set; }
  }
}
