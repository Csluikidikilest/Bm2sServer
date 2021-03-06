﻿
namespace Bm2s.Poco.Common.Parameter
{
  public class ArticlePartnerVat
  {
    public int Id { get; set; }

    public decimal Rate { get; set; }

    public decimal? Multiplier { get; set; }

    public string AccountingEntry { get; set; }

    public Article.Article Article { get; set; }

    public Partner.Partner Partner { get; set; }

    public Vat Vat { get; set; }
  }
}
