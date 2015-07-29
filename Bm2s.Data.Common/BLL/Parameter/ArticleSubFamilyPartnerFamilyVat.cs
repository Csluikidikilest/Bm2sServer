using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class ArticleSubFamilyPartnerFamilyVat : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Ignore]
    public ArticleSubFamily ArticleSubFamily { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [Ignore]
    public PartnerFamily PartnerFamily { get; set; }

    [References(typeof(Vat))]
    public int VatId { get; set; }

    [Ignore]
    public Vat Vat { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleSubFamily = Datas.Instance.DataStorage.ArticleSubFamilies.FirstOrDefault<ArticleSubFamily>(item => item.Id == this.ArticleSubFamilyId);
      this.PartnerFamily = Datas.Instance.DataStorage.PartnerFamilies.FirstOrDefault<Partner.PartnerFamily>(item => item.Id == this.PartnerFamilyId);
      this.Vat = Datas.Instance.DataStorage.Vats.FirstOrDefault<Vat>(item => item.Id == this.VatId);
    }
  }
}
