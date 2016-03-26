using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Nomenclature : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(1)]
    public int QuantityParent { get; set; }

    [Default(1)]
    public int QuantityChild { get; set; }

    public double BuyPrice { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Article))]
    public int ArticleParentId { get; set; }

    [References(typeof(Article))]
    public int ArticleChildId { get; set; }
  }
}
