using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Group;
using Bm2s.Response.Common.User.GroupModule;
using Bm2s.Response.Common.User.Module;
using Bm2s.Response.Common.User.User;
using Bm2s.Services.Common.User.Group;
using Bm2s.Services.Common.User.Module;
using Bm2s.Services.Common.User.User;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.GroupModule
{
  public class GroupModulesService : Service
  {
    public GroupModulesResponse Get(GroupModules request)
    {
      GroupModulesResponse response = new GroupModulesResponse();
      List<Bm2s.Data.Common.BLL.User.GroupModule> items = new List<Data.Common.BLL.User.GroupModule>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.GroupModules.Where(item =>
          (request.GrantorId == 0 || item.GrantorId == request.GrantorId) &&
          (request.GroupId == 0 || item.GroupId == request.GroupId) &&
          (request.ModuleId == 0 || item.ModuleId == request.ModuleId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.GroupModules.Where(item => request.Ids.Contains(item.Id)));
      }

      response.GroupModules.AddRange((from item in items
                                     select new Bm2s.Poco.Common.User.GroupModule()
                                     {
                                       Granted = item.Granted,
                                       Grantor = new UsersService().Get(new Users() { Ids = new List<int>() { item.GrantorId} }).Users.FirstOrDefault(),
                                       Group = new GroupsService().Get(new Groups() { Ids = new List<int>() { item.GroupId} }).Groups.FirstOrDefault(),
                                       Id = item.Id,
                                       Module = new ModulesService().Get(new Modules() { Ids = new List<int>() { item.ModuleId} }).Modules.FirstOrDefault()
                                     }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

      return response;
    }

    public GroupModulesResponse Post(GroupModules request)
    {
      if (request.GroupModule.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.GroupModule item = Datas.Instance.DataStorage.GroupModules[request.GroupModule.Id];
        item.Granted = request.GroupModule.Granted;
        item.GrantorId = request.GroupModule.Grantor.Id;
        item.GroupId = request.GroupModule.Group.Id;
        item.ModuleId = request.GroupModule.Module.Id;
        Datas.Instance.DataStorage.GroupModules[request.GroupModule.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.GroupModule item = new Data.Common.BLL.User.GroupModule()
        {
          Granted = request.GroupModule.Granted,
          GrantorId = request.GroupModule.Grantor.Id,
          GroupId = request.GroupModule.Group.Id,
          ModuleId = request.GroupModule.Module.Id
        };

        Datas.Instance.DataStorage.GroupModules.Add(item);
        request.GroupModule.Id = item.Id;
      }

      GroupModulesResponse response = new GroupModulesResponse();
      response.GroupModules.Add(request.GroupModule);
      return response;
    }
  }
}
