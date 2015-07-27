using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.User.UserModule
{
  public class UserModulesService : Service
  {
    public object Get(UserModules request)
    {
      UserModulesResponse response = new UserModulesResponse();

      if (!request.Ids.Any())
      {
        response.UserModules.AddRange(Datas.Instance.DataStorage.UserModules);
      }
      else
      {
        response.UserModules.AddRange(Datas.Instance.DataStorage.UserModules.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(UserModules request)
    {
      if (request.UserModule.Id > 0)
      {
        Datas.Instance.DataStorage.UserModules[request.UserModule.Id] = request.UserModule;
      }
      else
      {
        Datas.Instance.DataStorage.UserModules.Add(request.UserModule);
      }
      return request.UserModule;
    }
  }
}
