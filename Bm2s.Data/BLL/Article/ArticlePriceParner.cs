using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticlePriceParner
  {
    public decimal Price { get; set; }

    public decimal Multiplier { get; set; }

    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }
  }
}
