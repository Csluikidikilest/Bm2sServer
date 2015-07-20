using ServiceStack.ServiceHost;
using System;

namespace Bm2s.Data.Common.Services.Article.PriceDetermination
{
  [Route("/bm2s/prices/{ArticleId}/{PartnerId}/{Date}", Verbs = "GET")]
  public class PriceDetermination : IReturn<PriceDeterminationResponse>
  {
    public PriceDetermination()
    {
    }

    public int ArticleId { get; set; }

    public int PartnerId { get; set; }

    public DateTime Date { get; set; }
  }
}
