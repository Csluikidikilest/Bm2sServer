using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticlePriceParner : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

    [Default(0)]
    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article Article { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }
  }
}
