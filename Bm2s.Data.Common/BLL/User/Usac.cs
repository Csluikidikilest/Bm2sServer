using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class Usac : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool IsDefault { get; set; }

    [References(typeof(Acti))]
    public int ActiId { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }
  }
}
