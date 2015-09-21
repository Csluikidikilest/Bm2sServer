using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.User.Group
{
  public class GroupsResponse : Response
  {
    public GroupsResponse()
    {
      this.Groups = new List<Bm2s.Poco.Common.User.Group>();
    }

    public List<Bm2s.Poco.Common.User.Group> Groups { get; set; }
  }
}
