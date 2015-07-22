using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.Price
{
  [Route("/bm2s/prices", Verbs = "GET, POST")]
  [Route("/bm2s/prices/{Ids}", Verbs = "GET")]
  public class Prices : IReturn<PricesResponse>
  {
    public Prices()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.Price Price { get; set; }
  }
}
