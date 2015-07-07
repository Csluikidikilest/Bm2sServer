using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticlePriceParnerFamily
  {
    public decimal Price { get; set; }

    public decimal Multiplier { get; set; }

    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [References(typeof(Partner.PartnerFamily))]
    public int PartnerFamilyId { get; set; }
  }
}
