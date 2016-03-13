
namespace Bm2s.Poco.Common.Article
{
  public class Nomenclature
  {
    public int Id { get; set; }

    public int QuantityParent { get; set; }

    public int QuantityChild { get; set; }

    public double BuyPrice { get; set; }

    public Article ArticleParent { get; set; }

    public Article ArticleChild { get; set; }
  }
}
