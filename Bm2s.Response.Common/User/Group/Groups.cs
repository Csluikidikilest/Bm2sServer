using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.Group
{
  [Route("/bm2s/groups", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/groups/{Ids}", Verbs = "GET")]
  public class Groups : Request, IReturn<GroupsResponse>
  {
    public Groups()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public bool IsSystem { get; set; }

    public string Name { get; set; }

    public DateTime? Date { get; set; }

    public Bm2s.Poco.Common.User.Group Group { get; set; }
  }
}
