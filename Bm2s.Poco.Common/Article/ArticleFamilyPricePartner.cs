using System;

namespace Bm2s.Poco.Common.Article
{
  public class ArticleFamilyPricePartner
  {
    public int Id { get; set; }

    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    public double? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public ArticleFamily ArticleFamily { get; set; }

    public Partner.Partner Partner { get; set; }
  }
}
