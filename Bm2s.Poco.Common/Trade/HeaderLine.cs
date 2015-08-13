using Bm2s.Poco.Common.Article;
using Bm2s.Poco.Common.Parameter;

namespace Bm2s.Poco.Common.Trade
{
  public class HeaderLine
  {
    public int Id { get; set; }

    public int LineNumber { get; set; }

    public string Code { get; set; }

    public string Designation { get; set; }

    public string Description { get; set; }

    public double BuyPrice { get; set; }

    public double SellPrice { get; set; }

    public int Quantity { get; set; }

    public string PreparationObservation { get; set; }

    public string DeliveryObservation { get; set; }

    public string SupplierCompanyName { get; set; }

    public double VatRate { get; set; }

    public bool IsPrintable { get; set; }

    public Article.Article Article { get; set; }

    public ArticleFamily ArticleFamily { get; set; }

    public ArticleSubFamily ArticleSubFamily { get; set; }

    public Brand Brand { get; set; }

    public HeaderLineType HeaderLineType { get; set; }

    public Header Header { get; set; }

    public Unit Unit { get; set; }
  }
}
