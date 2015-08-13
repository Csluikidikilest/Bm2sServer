using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.Price
{
  public class PricesResponse
  {
    public PricesResponse()
    {
      this.Prices = new List<Bm2s.Poco.Common.Article.Price>();
    }

    public List<Bm2s.Poco.Common.Article.Price> Prices { get; set; }
  }
}
