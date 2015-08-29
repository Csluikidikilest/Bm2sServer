using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Group;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.Group
{
  public class GroupsService : Service
  {
    public GroupsResponse Get(Groups request)
    {
      GroupsResponse response = new GroupsResponse();
      List<Bm2s.Data.Common.BLL.User.Group> items = new List<Data.Common.BLL.User.Group>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Groups.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Groups.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Groups.AddRange((from item in items
                               select new Bm2s.Poco.Common.User.Group()
                               {
                                 Code = item.Code,
                                 Id = item.Id,
                                 Name = item.Name
                               }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

      return response;
    }

    public GroupsResponse Post(Groups request)
    {
      if (request.Group.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.Group item = Datas.Instance.DataStorage.Groups[request.Group.Id];
        item.Code = request.Group.Code;
        item.Name = request.Group.Name;
        Datas.Instance.DataStorage.Groups[request.Group.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.Group item = new Data.Common.BLL.User.Group()
        {
          Code = request.Group.Code,
          Name = request.Group.Name
        };

        Datas.Instance.DataStorage.Groups.Add(item);
        request.Group.Id = item.Id;
      }

      GroupsResponse response = new GroupsResponse();
      response.Groups.Add(request.Group);
      return response;
    }
  }
}
