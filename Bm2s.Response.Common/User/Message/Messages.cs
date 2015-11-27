using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.Message
{
  public class Messages: Request, IReturn<MessagesResponse>
  {
    public Messages()
    {
      this.Ids = new List<int>();
    }

    public string Subject { get; set; }

    public DateTime? SendDate { get; set; }

    public bool IsShortMessage { get; set; }

    public string Body { get; set; }

    public int UserId { get; set; }

    public Bm2s.Poco.Common.User.Message Message { get; set; }
  }
}
