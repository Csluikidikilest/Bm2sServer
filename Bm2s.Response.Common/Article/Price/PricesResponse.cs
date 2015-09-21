using System.Collections.Generic;

namespace Bm2s.Response.Common.Article.Price
{
  public class PricesResponse : Response
  {
    public PricesResponse()
    {
      this.Prices = new List<Bm2s.Poco.Common.Article.Price>();
    }

    public List<Bm2s.Poco.Common.Article.Price> Prices { get; set; }
  }
}
