using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.User.Group
{
  public class GroupsResponse
  {
    public GroupsResponse()
    {
      this.Groups = new List<BLL.User.Group>();
    }

    public List<BLL.User.Group> Groups { get; set; }
  }
}
