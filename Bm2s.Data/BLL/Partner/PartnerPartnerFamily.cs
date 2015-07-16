using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerPartnerFamily : Table
  {
    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner Partner { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [Ignore]
    public PartnerFamily PartnerFamily { get; set; }
  }
}
