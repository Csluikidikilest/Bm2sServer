using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class GroupModule
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public bool Granted { get; set; }

    [References(typeof(Group))]
    public int GroupId { get; set; }

    [References(typeof(Module))]
    public int ModuleId { get; set; }

    [References(typeof(User))]
    public int GrantorId { get; set; }
  }
}
