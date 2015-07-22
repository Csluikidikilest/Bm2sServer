using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class ArticlePartnerFamilyVat : Table
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

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article.Article Article { get; set; }

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
      this.Article = Datas.Instance.DataStorage.Articles.FirstOrDefault<Article.Article>(item => item.Id == this.ArticleId);
      this.PartnerFamily = Datas.Instance.DataStorage.PartnerFamilies.FirstOrDefault<Partner.PartnerFamily>(item => item.Id == this.PartnerFamilyId);
      this.Vat = Datas.Instance.DataStorage.Vats.FirstOrDefault<Vat>(item => item.Id == this.VatId);
    }
  }
}
