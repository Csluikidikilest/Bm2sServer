using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.User.Group
{
  [Route("/bm2s/groups", Verbs = "GET, POST")]
  [Route("/bm2s/groups/{Ids}", Verbs = "GET")]
  public class Groups
  {
    public Groups()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.User.Group Group { get; set; }
  }
}
