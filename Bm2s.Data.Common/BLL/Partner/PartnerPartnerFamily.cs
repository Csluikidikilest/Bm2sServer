using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  [Alias("Papf")]
  public class PartnerPartnerFamily : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Alias("PartId")]
    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [Alias("PafaId")]
    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }
  }
}
