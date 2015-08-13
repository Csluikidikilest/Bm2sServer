using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class GroupModule : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool Granted { get; set; }

    [References(typeof(Group))]
    public int GroupId { get; set; }

    [References(typeof(Module))]
    public int ModuleId { get; set; }

    [References(typeof(User))]
    public int GrantorId { get; set; }
  }
}
