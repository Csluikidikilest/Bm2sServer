using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.User.User
{
  [Route("/bm2s/users", Verbs = "GET, POST")]
  [Route("/bm2s/users/{Ids}", Verbs = "GET")]
  public class Users : IReturn<UsersResponse>
  {
    public Users()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.User.User User { get; set; }
  }
}
