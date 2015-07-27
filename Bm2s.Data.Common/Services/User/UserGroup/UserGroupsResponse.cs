using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.User.UserGroup
{
  public class UserGroupsResponse
  {
    public UserGroupsResponse()
    {
      this.UserGroups = new List<BLL.User.UserGroup>();
    }

    public List<BLL.User.UserGroup> UserGroups { get; set; }
  }
}
