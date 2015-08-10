using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.User
{
  public class UsersService : Service
  {
    public object Get(Users request)
    {
      UsersResponse response = new UsersResponse();

      if (!request.Ids.Any())
      {
        response.Users.AddRange(Datas.Instance.DataStorage.Users.Where(item =>
          (string.IsNullOrWhiteSpace(request.FirstName) || item.FirstName.ToLower().Contains(request.FirstName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.LastName) || item.LastName.ToLower().Contains(request.LastName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Login) || item.Login.ToLower().Contains(request.Login.ToLower())) &&
          (!request.IsAdministrator || item.IsAdministrator) &&
          (!request.IsAnonymous || item.IsAnonymous) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
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
