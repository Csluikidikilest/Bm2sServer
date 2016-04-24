using System;

namespace Bm2s.Poco.Common.Partner
{
  public class PartnerFile
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public Byte[] Content { get; set; }

    public DateTime AddingDate { get; set; }

    public Partner Partner { get; set; }

    public User.User User { get; set; }
  }
}
