using System;

namespace Bm2s.Poco.Common.Trade
{
  public class HeaderFile
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    public Header Header { get; set; }

    public User.User User { get; set; }
  }
}
