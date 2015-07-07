using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleSubFamilyPricePartnerFamily
  {
    public decimal Price { get; set; }

    public decimal Multiplier { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [References(typeof(Partner.PartnerFamily))]
    public int PartnerFamilyId { get; set; }
  }
}
