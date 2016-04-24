using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class Paad : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Addr))]
    public int AddrId { get; set; }

    [References(typeof(Adty))]
    public int AdtyId { get; set; }

    [References(typeof(Part))]
    public int PartId { get; set; }
  }
}
