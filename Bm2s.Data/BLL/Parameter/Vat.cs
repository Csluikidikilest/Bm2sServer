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
  public class Vat
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    public DateTime StaringDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public double Rate { get; set; }

    public string AccountingEntry { get; set; }

    [InverseProperty("Vat")]
    public List<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }

    [InverseProperty("Vat")]
    public List<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }

    [InverseProperty("Vat")]
    public List<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }

    [InverseProperty("Vat")]
    public List<ArticlePartnerVat> ArticlePartnerVats { get; set; }

    [InverseProperty("Vat")]
    public List<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }

    [InverseProperty("Vat")]
    public List<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
  }
}
