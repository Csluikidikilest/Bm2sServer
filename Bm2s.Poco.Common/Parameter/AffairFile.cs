using System;

namespace Bm2s.Poco.Common.Parameter
{
  public class AffairFile
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public Byte[] Content { get; set; }

    public DateTime AddingDate { get; set; }

    public Affair Affair { get; set; }

    public User.User User { get; set; }
  }
}
