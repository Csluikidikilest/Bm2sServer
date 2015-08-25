using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.User.UserModule;

namespace Bm2s.Connectivity.Common.User
{
  public class UserModule : ClientBase
  {
    public UserModule()
      : base()
    {
      this.Request = new UserModules();
      this.Response = new UserModulesResponse();
    }

    public UserModules Request { get; set; }

    public UserModulesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
