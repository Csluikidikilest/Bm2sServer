﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.User.UserModule
{
  [Route("/bm2s/usermodules", Verbs = "GET, POST")]
  [Route("/bm2s/usermodules/{Ids}", Verbs = "GET")]
  public class UserModules
  {
    public UserModules()
    {
      this.Ids = new List<int>();
    }

    public int GrantorId { get; set; }

    public List<int> Ids { get; set; }

    public int ModuleId { get; set; }

    public int UserId { get; set; }

    public BLL.User.UserModule UserModule { get; set; }
  }
}
