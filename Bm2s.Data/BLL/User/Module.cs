using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.User
{
  public class Module
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<GroupModule> GroupModules { get; set; }
  }
}
