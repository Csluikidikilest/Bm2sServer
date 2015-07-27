using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.User.GroupModule
{
  public class GroupModulesService : Service
  {
    public object Get(GroupModules request)
    {
      GroupModulesResponse response = new GroupModulesResponse();

      if (!request.Ids.Any())
      {
        response.GroupModules.AddRange(Datas.Instance.DataStorage.GroupModules);
      }
      else
      {
        response.GroupModules.AddRange(Datas.Instance.DataStorage.GroupModules.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(GroupModules request)
    {
      if (request.GroupModule.Id > 0)
      {
        Datas.Instance.DataStorage.GroupModules[request.GroupModule.Id] = request.GroupModule;
      }
      else
      {
        Datas.Instance.DataStorage.GroupModules.Add(request.GroupModule);
      }
      return request.GroupModule;
    }
  }
}
