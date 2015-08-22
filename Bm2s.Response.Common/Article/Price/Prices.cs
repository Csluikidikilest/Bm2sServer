using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Article.Price
{
  [Route("/bm2s/prices", Verbs = "GET, POST")]
  [Route("/bm2s/prices/{Ids}", Verbs = "GET")]
  public class Prices : IReturn<PricesResponse>
  {
    public Prices()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Poco.Common.Article.Price Price { get; set; }
  }
}
