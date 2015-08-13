using Bm2s.Poco.Common.Trade;

namespace Bm2s.Poco.Common.Parameter
{
  public class AffairHeader
  {
    public int Id { get; set; }

    public Affair Affair { get; set; }

    public Header Header { get; set; }
  }
}
