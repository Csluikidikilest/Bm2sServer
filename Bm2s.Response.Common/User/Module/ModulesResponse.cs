using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.User.Module
{
  public class ModulesResponse : Response
  {
    public ModulesResponse()
    {
      this.Modules = new List<Bm2s.Poco.Common.User.Module>();
    }

    public List<Bm2s.Poco.Common.User.Module> Modules { get; set; }
  }
}
