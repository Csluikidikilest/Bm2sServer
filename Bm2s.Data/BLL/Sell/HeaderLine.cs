using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Sell
{
  public class HeaderLine
  {
    public int Id { get; private set; }
    public int LineNumber { get; set; }
    public string Code { get; set; }
    public string Designation { get; set; }
    public string Description { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }
    public int Quantity { get; set; }
    public string PreparationObservation { get; set; }
    public string DeliveryObservation { get; set; }
    public string SupplierCompanyName { get; set; }
    public decimal VatRate { get; set; }
    public bool IsPrintable { get; set; }
    public Article.Article Article { get; set; }
    public ArticleFamily ArticleFamily { get; set; }
    public ArticleSubFamily ArticleSubFamily { get; set; }
    public Brand Brand { get; set; }
    public HeaderLineType HeaderLineType { get; set; }
    public Header Header { get; set; }
    public Unit Unit { get; set; }
    public List<Reconciliation> Reconciliations { get; set; }
  }
}
