using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Partner;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class ArticleFamilyPartnerVat
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [Required]
    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [References(typeof(Vat))]
    public int VatId { get; set; }
  }
}
