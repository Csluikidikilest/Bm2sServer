using System;

namespace Bm2s.Poco.Common.Trade
{
  public class HeaderOrigin
  {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public Header HeaderParent { get; set; }

    public Header HeaderChild { get; set; }
  }
}
