using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class PartnerPartnerFamily : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner Partner { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [Ignore]
    public PartnerFamily PartnerFamily { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.PartnerFamily = Datas.Instance.DataStorage.PartnerFamilies.FirstOrDefault<PartnerFamily>(item => item.Id == this.PartnerFamilyId);
    }
  }
}
