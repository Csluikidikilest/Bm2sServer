using System.Linq;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Hepa : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Head))]
    public int HeaderId { get; set; }

    [References(typeof(Addr))]
    public int AddressId { get; set; }

    [References(typeof(Adty))]
    public int AdtyId { get; set; }

    [References(typeof(Partner.Part))]
    public int PartId { get; set; }
  }
}
