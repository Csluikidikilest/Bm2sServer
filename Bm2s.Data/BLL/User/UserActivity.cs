using Bm2s.Data.BLL.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.User
{
  public class UserActivity
  {
    public bool IsDefault { get; set; }
    public Activity Activity { get; set; }
    public User User { get; set; }
  }
}
