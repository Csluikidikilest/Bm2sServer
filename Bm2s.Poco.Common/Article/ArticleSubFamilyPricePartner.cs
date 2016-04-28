using System;

namespace Bm2s.Poco.Common.Article
{
  public class ArticleSubFamilyPricePartner
  {
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public bool AddPrice { get; set; }

    public decimal? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public ArticleSubFamily ArticleSubFamily { get; set; }

    public Partner.Partner Partner { get; set; }
  }
}
