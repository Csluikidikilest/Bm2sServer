using Bm2s.Poco.Common.Article;
using Bm2s.Poco.Common.Partner;

namespace Bm2s.Poco.Common.Parameter
{
  public class ArticleFamilyPartnerFamilyVat
  {
    public int Id { get; set; }

    public double Rate { get; set; }

    public double? Multiplier { get; set; }

    public string AccountingEntry { get; set; }

    public ArticleFamily ArticleFamily { get; set; }

    public PartnerFamily PartnerFamily { get; set; }

    public Vat Vat { get; set; }
  }
}
