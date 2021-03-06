﻿using System;
using Bm2s.Poco.Common.Partner;

namespace Bm2s.Poco.Common.Article
{
  public class ArticleFamilyPricePartnerFamily
  {
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public decimal? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public ArticleFamily ArticleFamily { get; set; }

    public PartnerFamily PartnerFamily { get; set; }
  }
}
