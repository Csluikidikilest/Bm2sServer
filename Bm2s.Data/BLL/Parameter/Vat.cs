using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Vat
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    [Required] [StringLength(50)] public string Code { get; set; }
    public DateTime StaringDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public double Rate { get; set; }
    public string AccountingEntry { get; set; }
    public List<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
    public List<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
    public List<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
    public List<ArticlePartnerVat> ArticlePartnerVats { get; set; }
    public List<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
    public List<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
  }
}
