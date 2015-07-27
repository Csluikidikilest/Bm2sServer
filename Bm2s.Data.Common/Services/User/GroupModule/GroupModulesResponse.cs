using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.User.GroupModule
{
  public class GroupModulesResponse
  {
    public GroupModulesResponse()
    {
      this.GroupModules = new List<BLL.User.GroupModule>();
    }

    public List<BLL.User.GroupModule> GroupModules { get; set; }
  }
}
