﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerVat
{
  [Route("/bm2s/articlepartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlepartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticlePartnerVats : IReturn<ArticlePartnerVatsResponse>
  {
    public ArticlePartnerVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Poco.Common.Parameter.ArticlePartnerVat ArticlePartnerVat { get; set; }
  }
}
