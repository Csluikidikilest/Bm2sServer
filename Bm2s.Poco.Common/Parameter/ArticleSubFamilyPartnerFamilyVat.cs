using Bm2s.Poco.Common.Article;
using Bm2s.Poco.Common.Partner;

namespace Bm2s.Poco.Common.Parameter
{
  public class ArticleSubFamilyPartnerFamilyVat
  {
    public int Id { get; set; }

    public decimal Rate { get; set; }

    public decimal? Multiplier { get; set; }

    public string AccountingEntry { get; set; }

    public ArticleSubFamily ArticleSubFamily { get; set; }

    public PartnerFamily PartnerFamily { get; set; }

    public Vat Vat { get; set; }
  }
}
