using System.Collections.Generic;

namespace Bm2s.Response.Common.User.Message
{
  public class MessagesResponse : Response
  {
    public MessagesResponse()
    {
      this.Messages= new List<Poco.Common.User.Message>();
    }

    public List<Bm2s.Poco.Common.User.Message> Messages { get; set; }
  }
}
