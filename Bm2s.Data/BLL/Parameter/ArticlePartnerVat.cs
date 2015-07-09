using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class ArticlePartnerVat
  {
    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [Required]
    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [PrimaryKey]
    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [ForeignKey("ArticleId")]
    public Article.Article Article { get; set; }

    [PrimaryKey]
    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner.Partner Partner { get; set; }

    [PrimaryKey]
    [References(typeof(Vat))]
    public int VatId { get; set; }

    [ForeignKey("VatId")]
    public Vat Vat { get; set; }
  }
}
