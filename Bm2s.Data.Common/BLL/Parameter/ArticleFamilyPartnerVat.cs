using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Afpv")]
  public class ArticleFamilyPartnerVat : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [Alias("ArfaId")]
    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [Alias("PartId")]
    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Alias("VatId")]
    [References(typeof(Vat))]
    public int VatId { get; set; }
  }
}
