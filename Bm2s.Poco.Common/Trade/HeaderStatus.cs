using System;

namespace Bm2s.Poco.Common.Trade
{
  public class HeaderStatus
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public bool InterveneOnStock { get; set; }
  }
}
