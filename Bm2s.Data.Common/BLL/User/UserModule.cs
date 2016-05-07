using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  [Alias("Usmo")]
  public class UserModule : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool Granted { get; set; }

    [Alias("UserId")]
    [References(typeof(User))]
    public int UserId { get; set; }

    [Alias("ModuId")]
    [References(typeof(Module))]
    public int ModuleId { get; set; }

    [Alias("GranId")]
    [References(typeof(User))]
    public int GrantorId { get; set; }
  }
}
