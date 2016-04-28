using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Module;
using Bm2s.Response.Common.User.User;
using Bm2s.Response.Common.User.UserModule;
using Bm2s.Services.Common.User.Module;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.UserModule
{
  public class UserModulesService : Service
  {
    public UserModulesResponse Get(UserModules request)
    {
      UserModulesResponse response = new UserModulesResponse();
      List<Bm2s.Data.Common.BLL.User.Usmo> items = new List<Data.Common.BLL.User.Usmo>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.UserModules.Where(item =>
          (request.GrantorId == 0 || item.GranId == request.GrantorId) &&
          (request.ModuleId == 0 || item.ModuId == request.ModuleId) &&
          (request.UserId == 0 || item.UserId == request.UserId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.UserModules.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.User.UserModule()
                        {
                          Granted = item.Granted,
                          Grantor = new UsersService().Get(new Users() { Ids = new List<int>() { item.GranId } }).Users.FirstOrDefault(),
                          Id = item.Id,
                          Module = new ModulesService().Get(new Modules() { Ids = new List<int>() { item.ModuId } }).Modules.FirstOrDefault(),
                          User = new UsersService().Get(new Users() { Ids = new List<int>() { item.UserId } }).Users.FirstOrDefault()
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.UserModules.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.UserModules.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.UserModules.Count + (collection.Count() % response.UserModules.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public UserModulesResponse Post(UserModules request)
    {
      if (request.UserModule.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.Usmo item = Datas.Instance.DataStorage.UserModules[request.UserModule.Id];
        item.Granted = request.UserModule.Granted;
        item.GranId = request.UserModule.Grantor.Id;
        item.ModuId = request.UserModule.Module.Id;
        item.UserId = request.UserModule.User.Id;
        Datas.Instance.DataStorage.UserModules[request.UserModule.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.Usmo item = new Data.Common.BLL.User.Usmo()
        {
          Granted = request.UserModule.Granted,
          GranId = request.UserModule.Grantor.Id,
          ModuId = request.UserModule.Module.Id,
          UserId = request.UserModule.User.Id
        };

        Datas.Instance.DataStorage.UserModules.Add(item);
        request.UserModule.Id = item.Id;
      }

      UserModulesResponse response = new UserModulesResponse();
      response.UserModules.Add(request.UserModule);
      return response;
    }

    public UserModulesResponse Delete(UserModules request)
    {
      Bm2s.Data.Common.BLL.User.Usmo item = Datas.Instance.DataStorage.UserModules[request.UserModule.Id];
      Datas.Instance.DataStorage.UserModules.Remove(item);

      UserModulesResponse response = new UserModulesResponse();
      response.UserModules.Add(request.UserModule);
      return response;
    }
  }
}
