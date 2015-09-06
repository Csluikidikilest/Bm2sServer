using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Language;
using Bm2s.Response.Common.User.Login;
using Bm2s.Services.Common.Parameter.Language;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.Login
{
  public class LoginService : Service
  {
    public LoginResponse Get(Bm2s.Response.Common.User.Login.Login request)
    {
      LoginResponse response = new LoginResponse();
      Bm2s.Data.Common.BLL.User.User user = Datas.Instance.DataStorage.Users.FirstOrDefault(item => item.Login == request.UserLogin && item.Password == request.Password);

      response.User = new Poco.Common.User.User()
      {
        DefaultLanguage = new LanguagesService().Get(new Languages() { Ids = new List<int>() { user.DefaultLanguageId } }).Languages.FirstOrDefault(),
        EndingDate = user.EndingDate,
        FirstName = user.FirstName,
        Id = user.Id,
        IsAdministrator = user.IsAdministrator,
        IsAnonymous = user.IsAnonymous,
        LastName = user.LastName,
        Login = user.Login,
        Password = user.Password,
        StartingDate = user.StartingDate
      };
      return response;
    }
  }
}
