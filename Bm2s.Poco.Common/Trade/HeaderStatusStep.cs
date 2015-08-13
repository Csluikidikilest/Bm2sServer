
namespace Bm2s.Poco.Common.Trade
{
  public class HeaderStatusStep
  {
    public int Id { get; set; }

    public HeaderStatus HeaderStatusParent { get; set; }

    public HeaderStatus HeaderStatusChild { get; set; }
  }
}
