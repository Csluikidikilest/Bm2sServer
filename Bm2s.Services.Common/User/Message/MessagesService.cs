using System;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Message;
using Bm2s.Response.Common.User.User;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.Message
{
  public class MessagesService : Service
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
          (request.UserId == 0 || item.UserId == request.UserId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Messages.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                         select new Bm2s.Poco.Common.User.Message(){
                           Body = item.Body,
                           Id= item.Id,
                           IsShortMessage = item.IsShortMessage,
                           SendDate = item.SendDate,
                           Subject = item.Subject,
                           User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                         }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if(request.PageSize>0)
      {
        response.Messages.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Messages.AddRange(collection);
      }

      return response;
    }

    public MessagesResponse Post(Messages request)
    {
      if (request.Message.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.Message item = Datas.Instance.DataStorage.Messages[request.Message.Id];
        item.Body = request.Message.Body;
        item.IsShortMessage = request.Message.IsShortMessage;
        item.SendDate = request.Message.SendDate;
        item.Subject = request.Message.Subject;
        item.UserId = request.Message.User.Id;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.Message item = new Data.Common.BLL.User.Message()
        {
          Body = request.Message.Body,
          IsShortMessage = request.Message.IsShortMessage,
          SendDate = request.Message.SendDate,
          Subject = request.Message.Subject,
          UserId = request.Message.User.Id
        };

        Datas.Instance.DataStorage.Messages.Add(item);
        request.Message.Id = item.Id;
      }

      MessagesResponse response = new MessagesResponse();
      response.Messages.Add(request.Message);
      return response;
    }

    public MessagesResponse Delete(Messages request)
    {
      Bm2s.Data.Common.BLL.User.Message item = Datas.Instance.DataStorage.Messages[request.Message.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.Messages[item.Id] = item;

      MessagesResponse response = new MessagesResponse();
      response.Messages.Add(request.Message);
      return response;
    }
  }
}
