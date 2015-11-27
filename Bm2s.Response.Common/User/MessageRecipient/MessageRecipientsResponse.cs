using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.User.MessageRecipient
{
  public class MessageRecipientsResponse : Response
  {
    public MessageRecipientsResponse()
    {
      this.MessageRecipients = new List<Poco.Common.User.MessageRecipient>();
    }

    public List<Bm2s.Poco.Common.User.MessageRecipient> MessageRecipients { get; set; }
  }
}
