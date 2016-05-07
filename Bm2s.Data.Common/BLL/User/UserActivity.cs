using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  [Alias("Usac")]
  public class UserActivity : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool IsDefault { get; set; }

    [Alias("ActiId")]
    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [Alias("UserId")]
    [References(typeof(User))]
    public int UserId { get; set; }
  }
}
