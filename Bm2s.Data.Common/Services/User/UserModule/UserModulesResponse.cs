using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.User.UserModule
{
  public class UserModulesResponse
  {
    public UserModulesResponse()
    {
      this.UserModules = new List<BLL.User.UserModule>();
    }

    public List<BLL.User.UserModule> UserModules { get; set; }
  }
}
