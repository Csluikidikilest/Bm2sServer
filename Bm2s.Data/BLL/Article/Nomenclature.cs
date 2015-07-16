using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class Nomenclature : Table
  {
    [Default(0)]
    public int? Quantity { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public double BuyPrice { get; set; }

    [References(typeof(Article))]
    public int ArticleParentId { get; set; }

    [Ignore]
    public Article ArticleParent { get; set; }

    [References(typeof(Article))]
    public int ArticleChildId { get; set; }

    [Ignore]
    public Article ArticleChild { get; set; }
  }
}
