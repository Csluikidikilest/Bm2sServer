using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  [Alias("Aspp")]
  public class ArticleSubFamilyPricePartner : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [Alias("ArsfId")]
    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Alias("PartId")]
    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }
  }
}
