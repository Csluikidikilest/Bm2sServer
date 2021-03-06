﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticleSubFamilyPricePartner
{
  public class ArticleSubFamilyPricePartnersResponse : Response
  {
    public ArticleSubFamilyPricePartnersResponse()
    {
      this.ArticleSubFamilyPricePartners = new List<Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartner>();
    }

    public List<Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }
  }
}
