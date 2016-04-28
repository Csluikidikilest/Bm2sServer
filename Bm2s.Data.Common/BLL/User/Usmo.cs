using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class Usmo : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public bool Granted { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }

    [References(typeof(Modu))]
    public int ModuId { get; set; }

    [References(typeof(User))]
    public int GranId { get; set; }
  }
}
