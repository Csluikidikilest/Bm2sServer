using ServiceStack.ServiceHost;
using System;

namespace Bm2s.Response.Common.Article.PriceDetermination
{
  [Route("/bm2s/pricedetermination/{ArticleId}/{PartnerId}/{Date}", Verbs = "GET")]
  public class PriceDetermination : Request, IReturn<PriceDeterminationResponse>
  {
    public PriceDetermination()
    {
    }

    public int ArticleId { get; set; }

    public int PartnerId { get; set; }

    public DateTime Date { get; set; }
  }
}
