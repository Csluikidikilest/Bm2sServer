using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class ArticleFamilyPartnerVat : Table
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

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [Ignore]
    public ArticleFamily ArticleFamily { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }

    [References(typeof(Vat))]
    public int VatId { get; set; }

    [Ignore]
    public Vat Vat { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleFamily = Datas.Instance.DataStorage.ArticleFamilies.FirstOrDefault<ArticleFamily>(item => item.Id == this.ArticleFamilyId);
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner.Partner>(item => item.Id == this.PartnerId);
      this.Vat = Datas.Instance.DataStorage.Vats.FirstOrDefault<Vat>(item => item.Id == this.VatId);
    }
  }
}
