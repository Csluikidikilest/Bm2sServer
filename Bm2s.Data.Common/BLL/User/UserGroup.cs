using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  [Alias("Usgr")]
  public class UserGroup : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Alias("UserId")]
    [References(typeof(User))]
    public int UserId { get; set; }

    [Alias("GrouId")]
    [References(typeof(Group))]
    public int GroupId { get; set; }
  }
}
