using System;

namespace Bm2s.Poco.Common.User
{
  public class MessageRecipient
  {
    public int Id { get; set; }

    public DateTime ReadingDate { get; set; }

    public Message Message { get; set; }

    public User User { get; set; }
  }
}
