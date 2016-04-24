using System.Linq;
using Bm2s.Data.Common.BLL.Trade;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Afhe : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Affa))]
    public int AffaId { get; set; }

    [References(typeof(Head))]
    public int HeadId { get; set; }
  }
}
