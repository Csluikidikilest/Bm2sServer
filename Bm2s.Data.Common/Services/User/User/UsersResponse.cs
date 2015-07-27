using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.User.User
{
  public class UsersResponse
  {
    public UsersResponse()
    {
      this.Users = new List<BLL.User.User>();
    }

    public List<BLL.User.User> Users { get; set; }
  }
}
