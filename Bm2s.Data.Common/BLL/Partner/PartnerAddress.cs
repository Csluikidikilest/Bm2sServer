using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  [Alias("Paad")]
  public class PartnerAddress : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Alias("AddrId")]
    [References(typeof(Address))]
    public int AddressId { get; set; }

    [Alias("AdtyId")]
    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [Alias("PartId")]
    [References(typeof(Partner))]
    public int PartnerId { get; set; }
  }
}
