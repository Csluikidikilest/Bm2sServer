using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.User.Group
{
  public class GroupsResponse
  {
    public GroupsResponse()
    {
      this.Groups = new List<Bm2s.Data.Common.BLL.User.Group>();
    }

    public List<Bm2s.Data.Common.BLL.User.Group> Groups { get; set; }
  }
}
