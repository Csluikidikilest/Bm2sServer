using System;
using Bm2s.Poco.Common.Partner;

namespace Bm2s.Poco.Common.Article
{
  public class ArticlePricePartnerFamily
  {
    public int Id { get; set; }

    public double? Price { get; set; }

    public double? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Article Article { get; set; }

    public PartnerFamily PartnerFamily { get; set; }
  }
}
