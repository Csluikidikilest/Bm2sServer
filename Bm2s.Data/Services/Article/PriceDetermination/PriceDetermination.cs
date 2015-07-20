using ServiceStack.ServiceHost;
using System;

namespace Bm2s.Data.Services.Article.PriceDetermination
{
  [Route("/bm2s/prices/{ArtiId}/{PartId}/{Date}", Verbs = "GET")]
  public class PriceDetermination : IReturn<PriceDeterminationResponse>
  {
    public PriceDetermination()
    {
    }

    public int ArtiId { get; set; }

    public int PartId { get; set; }

    public DateTime Date { get; set; }
  }
}
