using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.User.Module
{
  public class ModulesResponse
  {
    public ModulesResponse()
    {
      this.Modules = new List<BLL.User.Module>();
    }

    public List<BLL.User.Module> Modules { get; set; }
  }
}
