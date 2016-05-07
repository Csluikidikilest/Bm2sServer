using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  [Alias("Grmo")]
  public class GroupModule : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool Granted { get; set; }

    [Alias("GrouId")]
    [References(typeof(Group))]
    public int GroupId { get; set; }

    [Alias("ModuId")]
    [References(typeof(Module))]
    public int ModuleId { get; set; }

    [Alias("GranId")]
    [References(typeof(User))]
    public int GrantorId { get; set; }
  }
}
