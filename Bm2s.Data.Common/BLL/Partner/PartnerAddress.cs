using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class PartnerAddress : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [References(typeof(AddressType))]
    public int AddressTypeId { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }
  }
}
