using System.Collections.Generic;

namespace Bm2s.Data.Services.Article.PriceDetermination
{
  public class PriceDeterminationResponse
  {
    public PriceDeterminationResponse()
    {
      this.Prices = new List<BLL.Article.Price>();
    }

    public List<BLL.Article.Price> Prices { get; set; }
  }
}
