using System;

namespace Bm2s.Poco.Common.Article
{
  public class Price
  {
    public int Id { get; set; }

    public decimal BasePrice { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public Article Article { get; set; }
  }
}
