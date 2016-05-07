using System;
using System.Linq;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  [Alias("Afpf")]
  public class ArticleFamilyPricePartnerFamily : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double? Price { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [Alias("ArfaId")]
    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [Alias("PafaId")]
    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }
  }
}
