using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.MessageRecipient
{
  public class MessageRecipients: Request, IReturn<MessageRecipientsResponse>
  {
    public MessageRecipients()
    {
      this.Ids = new List<int>();
    }

    public int MessageId { get; set; }

    public int UserId { get; set; }

    public Bm2s.Poco.Common.User.MessageRecipient MessageRecipient { get; set; }
  }
}
