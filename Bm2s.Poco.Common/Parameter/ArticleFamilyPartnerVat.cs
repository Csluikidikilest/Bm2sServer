using Bm2s.Poco.Common.Article;

namespace Bm2s.Poco.Common.Parameter
{
  public class ArticleFamilyPartnerVat
  {
    public int Id { get; set; }

    public double Rate { get; set; }

    public double? Multiplier { get; set; }

    public string AccountingEntry { get; set; }

    public ArticleFamily ArticleFamily { get; set; }

    public Partner.Partner Partner { get; set; }

    public Vat Vat { get; set; }
  }
}
