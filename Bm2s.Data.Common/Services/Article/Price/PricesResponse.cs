using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.Price
{
  public class PricesResponse
  {
    public PricesResponse()
    {
      this.Prices = new List<BLL.Article.Price>();
    }

    public List<BLL.Article.Price> Prices { get; set; }
  }
}
