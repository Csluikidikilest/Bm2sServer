using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class ArticlePartnerVat : Table
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
      this.Article= Datas.Instance.DataStorage.Articles.FirstOrDefault<Article.Article>(item => item.Id == this.ArticleId);
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner.Partner>(item => item.Id == this.PartnerId);
      this.Vat = Datas.Instance.DataStorage.Vats.FirstOrDefault<Vat>(item => item.Id == this.VatId);
    }
  }
}
