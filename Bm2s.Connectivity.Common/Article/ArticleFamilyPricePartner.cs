﻿using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Article.ArticleFamilyPricePartner;

namespace Bm2s.Connectivity.Common.Article
{
  public class ArticleFamilyPricePartner : ClientBase
  {
    public ArticleFamilyPricePartner()
      : base()
    {
      this.Request = new ArticleFamilyPricePartners();
      this.Response = new ArticleFamilyPricePartnersResponse();
    }

    public ArticleFamilyPricePartners Request { get; set; }

    public ArticleFamilyPricePartnersResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
