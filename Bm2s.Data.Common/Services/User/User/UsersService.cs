using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.User.User
{
  public class UsersService : Service
  {
    public object Get(Users request)
    {
      UsersResponse response = new UsersResponse();

      if (!request.Ids.Any())
      {
        response.Users.AddRange(Datas.Instance.DataStorage.Users);
      }
      else
      {
        response.Users.AddRange(Datas.Instance.DataStorage.Users.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(Users request)
    {
      if (request.User.Id > 0)
      {
        Datas.Instance.DataStorage.Users[request.User.Id] = request.User;
      }
      else
      {
        Datas.Instance.DataStorage.Users.Add(request.User);
      }
      return request.User;
    }
  }
}
