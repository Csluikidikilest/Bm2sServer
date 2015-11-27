using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Message;

namespace Bm2s.Services.Common.User.Message
{
  public class MessagesService
  {
    public MessagesResponse Get(Messages request)
    {
      MessagesResponse response = new MessagesResponse();
      List<Bm2s.Data.Common.BLL.User.Message> items = new List<Data.Common.BLL.User.Message>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Messages.Where(item =>
          (string.IsNullOrWhiteSpace(request.Body) || item.Body.ToLower().Contains(request.Body.ToLower())) &&
          (!request.IsShortMessage || item.IsShortMessage) &&
          (request.SendDate.HasValue || item.SendDate >= request.SendDate) &&
          (string.IsNullOrWhiteSpace(request.Subject) || item.Subject.ToLower().Contains(request.Subject.ToLower())) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Messages.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }
  }
}
