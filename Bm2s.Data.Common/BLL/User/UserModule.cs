﻿using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class UserModule : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool Granted { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }

    [References(typeof(Module))]
    public int ModuleId { get; set; }

    [References(typeof(User))]
    public int GrantorId { get; set; }
  }
}
