using System;

namespace Bm2s.Poco.Common.User
{
  public class Message
  {
    public int Id { get; set; }

    public string Subject { get; set; }

    public DateTime SendDate { get; set; }

    public bool IsShortMessage { get; set; }

    public string Body { get; set; }

    public User User { get; set; }
  }
}
