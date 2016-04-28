using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Message;
using Bm2s.Response.Common.User.MessageRecipient;
using Bm2s.Response.Common.User.User;
using Bm2s.Services.Common.User.Message;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.MessageRecipient
{
  public class MessageRecipientsService : Service
  {
    public MessageRecipientsResponse Get(MessageRecipients request)
    {
      MessageRecipientsResponse response = new MessageRecipientsResponse();
      List<Bm2s.Data.Common.BLL.User.Mere> items = new List<Data.Common.BLL.User.Mere>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.MessageRecipients.Where(item =>
          (request.MessageId == 0 || item.MessId == request.MessageId) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.MessageRecipients.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.User.MessageRecipient()
                        {
                          Id = item.Id,
                          Message = new MessagesService().Get(new Messages() { Ids = new List<int>() { item.MessId } }).Messages.FirstOrDefault(),
                          ReadingDate = item.ReadingDate,
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.MessageRecipients.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.MessageRecipients.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.MessageRecipients.Count + (collection.Count() % response.MessageRecipients.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public MessageRecipientsResponse Post(MessageRecipients request)
    {
      if (request.MessageRecipient.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.Mere item = Datas.Instance.DataStorage.MessageRecipients[request.MessageRecipient.Id];
        item.MessId = request.MessageRecipient.Message.Id;
        item.ReadingDate = request.MessageRecipient.ReadingDate;
        item.UserId = request.MessageRecipient.User.Id;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.Mere item = new Data.Common.BLL.User.Mere()
        {
          MessId = request.MessageRecipient.Message.Id,
          ReadingDate = request.MessageRecipient.ReadingDate,
          UserId = request.MessageRecipient.User.Id
        };

        Datas.Instance.DataStorage.MessageRecipients.Add(item);
        request.MessageRecipient.Id = item.Id;
      }

      MessageRecipientsResponse response = new MessageRecipientsResponse();
      response.MessageRecipients.Add(request.MessageRecipient);
      return response;
    }

    public MessageRecipientsResponse Delete(MessageRecipients request)
    {
      Bm2s.Data.Common.BLL.User.Mere item = Datas.Instance.DataStorage.MessageRecipients[request.MessageRecipient.Id];
      Datas.Instance.DataStorage.MessageRecipients.Remove(item);

      MessageRecipientsResponse response = new MessageRecipientsResponse();
      response.MessageRecipients.Add(request.MessageRecipient);
      return response;
    }
  }
}
