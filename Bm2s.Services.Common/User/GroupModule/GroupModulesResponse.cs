using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.User.GroupModule
{
  public class GroupModulesResponse
  {
    public GroupModulesResponse()
    {
      this.GroupModules = new List<Bm2s.Data.Common.BLL.User.GroupModule>();
    }

    public List<Bm2s.Data.Common.BLL.User.GroupModule> GroupModules { get; set; }
  }
}
