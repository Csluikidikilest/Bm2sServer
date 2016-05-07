using System.Linq;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  [Alias("Hepa")]
  public class HeaderPartnerAddress : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Alias("HeadId")]
    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Alias("AddrId")]
    [References(typeof(Address))]
    public int AddressId { get; set; }

    [Alias("AdtyId")]
    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [Alias("PartId")]
    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }
  }
}
