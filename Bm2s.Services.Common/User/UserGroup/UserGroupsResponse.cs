using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.User.UserGroup
{
  public class UserGroupsResponse
  {
    public UserGroupsResponse()
    {
      this.UserGroups = new List<Bm2s.Poco.Common.User.UserGroup>();
    }

    public List<Bm2s.Poco.Common.User.UserGroup> UserGroups { get; set; }
  }
}
