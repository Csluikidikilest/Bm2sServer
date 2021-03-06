﻿using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticlePricePartnerFamily
{
  [Route("/bm2s/articlepricepartnerfamilies", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/articlepricepartnerfamilies/{Ids}", Verbs = "GET")]
  public class ArticlePricePartnerFamilies : Request, IReturn<ArticlePricePartnerFamiliesResponse>
  {
    public ArticlePricePartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public DateTime? Date { get; set; }

    public int PartnerFamilyId { get; set; }

    public Bm2s.Poco.Common.Article.ArticlePricePartnerFamily ArticlePricePartnerFamily { get; set; }
  }
}
