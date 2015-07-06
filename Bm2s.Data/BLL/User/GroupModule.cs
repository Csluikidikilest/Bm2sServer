using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.User
{
  public class GroupModule
  {
    public bool Granted { get; set; }
    public Group Group { get; set; }
    public Module Module { get; set; }
    public User Grantor { get; set; }
  }
}
