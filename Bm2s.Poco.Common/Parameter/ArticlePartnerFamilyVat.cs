﻿using Bm2s.Poco.Common.Partner;

namespace Bm2s.Poco.Common.Parameter
{
  public class ArticlePartnerFamilyVat
  {
    public int Id { get; set; }

    public decimal Rate { get; set; }

    public decimal? Multiplier { get; set; }

    public string AccountingEntry { get; set; }

    public Article.Article Article { get; set; }

    public PartnerFamily PartnerFamily { get; set; }

    public Vat Vat { get; set; }
  }
}
