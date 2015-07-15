using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleSubFamilyPricePartner
  {
    [Default(0)]
    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [ForeignKey("ArticleSubFamilyId")]
    public ArticleSubFamily ArticleSubFamily { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner.Partner Partner { get; set; }
  }
}
