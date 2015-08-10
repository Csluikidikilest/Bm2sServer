using System.Collections.Generic;

namespace Bm2s.Services.Common.User.UserModule
{
  public class UserModulesResponse
  {
    public UserModulesResponse()
    {
      this.UserModules = new List<Bm2s.Data.Common.BLL.User.UserModule>();
    }

    public List<Bm2s.Data.Common.BLL.User.UserModule> UserModules { get; set; }
  }
}
