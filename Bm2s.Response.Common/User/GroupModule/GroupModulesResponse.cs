using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.User.GroupModule
{
  public class GroupModulesResponse : Response
  {
    public GroupModulesResponse()
    {
      this.GroupModules = new List<Bm2s.Poco.Common.User.GroupModule>();
    }

    public List<Bm2s.Poco.Common.User.GroupModule> GroupModules { get; set; }
  }
}
