using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class Nomenclature
  {
    public int Quantity { get; set; }

    public decimal BuyPrice { get; set; }

    [References(typeof(Article))]
    public int ArticleParentId { get; set; }

    [References(typeof(Article))]
    public int ArticleChildId { get; set; }
  }
}
