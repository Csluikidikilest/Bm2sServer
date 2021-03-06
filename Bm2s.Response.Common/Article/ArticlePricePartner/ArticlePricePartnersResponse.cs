﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticlePriceParner
{
  public class ArticlePricePartnersResponse : Response
  {
    public ArticlePricePartnersResponse()
    {
      this.ArticlePricePartners = new List<Bm2s.Poco.Common.Article.ArticlePricePartner>();
    }

    public List<Bm2s.Poco.Common.Article.ArticlePricePartner> ArticlePricePartners { get; set; }
  }
}
