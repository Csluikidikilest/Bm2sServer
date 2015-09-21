using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.User.User
{
  public class UsersResponse : Response
  {
    public UsersResponse()
    {
      this.Users = new List<Bm2s.Poco.Common.User.User>();
    }

    public List<Bm2s.Poco.Common.User.User> Users { get; set; }
  }
}
