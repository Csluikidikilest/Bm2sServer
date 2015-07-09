using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderLine
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public int LineNumber { get; set; }

    [Required]
    [StringLength(50)]
    public string Code { get; set; }

    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    [Default(0)]
    public double BuyPrice { get; set; }

    public double SellPrice { get; set; }

    [Default(1)]
    public int Quantity { get; set; }

    public string? PreparationObservation { get; set; }

    public string? DeliveryObservation { get; set; }

    public string? SupplierCompanyName { get; set; }

    public double VatRate { get; set; }

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
