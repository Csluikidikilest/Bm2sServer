using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerPartnerFamily : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

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
