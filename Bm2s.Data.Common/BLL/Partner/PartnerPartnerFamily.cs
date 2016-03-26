using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class PartnerPartnerFamily : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }
  }
}
