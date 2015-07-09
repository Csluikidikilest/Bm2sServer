using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  [Table("ArticlePriceParner", Schema = "Article")]
  public class ArticlePriceParner
  {
    [Default(0)]
    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [PrimaryKey]
    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [ForeignKey("ArticleId")]
    public Article Article { get; set; }

    [PrimaryKey]
    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner.Partner Partner { get; set; }
  }
}
