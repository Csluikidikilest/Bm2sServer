using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.User.Module
{
  public class ModulesResponse
  {
    public ModulesResponse()
    {
      this.Modules = new List<Bm2s.Data.Common.BLL.User.Module>();
    }

    public List<Bm2s.Data.Common.BLL.User.Module> Modules { get; set; }
  }
}
