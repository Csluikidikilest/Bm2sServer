﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticleFamilyPricePartnerFamily
{
  public class ArticleFamilyPricePartnerFamiliesResponse : Response
  {
    public ArticleFamilyPricePartnerFamiliesResponse()
    {
      this.ArticleFamilyPricePartnerFamilies = new List<Bm2s.Poco.Common.Article.ArticleFamilyPricePartnerFamily>();
    }

    public List<Bm2s.Poco.Common.Article.ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
  }
}
