using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Group;
using Bm2s.Response.Common.User.User;
using Bm2s.Response.Common.User.UserGroup;
using Bm2s.Services.Common.User.Group;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.UserGroup
{
  public class UserGroupsService : Service
  {
    public UserGroupsResponse Get(UserGroups request)
    {
      UserGroupsResponse response = new UserGroupsResponse();
      List<Bm2s.Data.Common.BLL.User.UserGroup> items = new List<Data.Common.BLL.User.UserGroup>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.UserGroups.Where(item =>
          (request.GroupId == 0 || item.GroupId == request.GroupId) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.UserGroups.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.User.UserGroup()
                        {
                          Group = new GroupsService().Get(new Groups() { Ids = new List<int>() { item.GroupId } }).Groups.FirstOrDefault(),
                          Id = item.Id,
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.UserGroups.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.UserGroups.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.UserGroups.Count + (collection.Count() % response.UserGroups.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public UserGroupsResponse Post(UserGroups request)
    {
      if (request.UserGroup.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.UserGroup item = Datas.Instance.DataStorage.UserGroups[request.UserGroup.Id];
        item.GroupId = request.UserGroup.Group.Id;
        item.UserId = request.UserGroup.User.Id;
        Datas.Instance.DataStorage.UserGroups[request.UserGroup.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.UserGroup item = new Data.Common.BLL.User.UserGroup()
        {
          GroupId = request.UserGroup.Group.Id,
          UserId = request.UserGroup.User.Id
        };

        Datas.Instance.DataStorage.UserGroups.Add(item);
        request.UserGroup.Id = item.Id;
      }

      UserGroupsResponse response = new UserGroupsResponse();
      response.UserGroups.Add(request.UserGroup);
      return response;
    }

    public UserGroupsResponse Delete(UserGroups request)
    {
      Bm2s.Data.Common.BLL.User.UserGroup item = Datas.Instance.DataStorage.UserGroups.FirstOrDefault(nomenclature => nomenclature.Id == request.UserGroup.Id);
      if (item != null)
      {
        Datas.Instance.DataStorage.UserGroups.Remove(item);
      }

      UserGroupsResponse response = new UserGroupsResponse();
      response.UserGroups.Add(request.UserGroup);
      return response;
    }
  }
}
