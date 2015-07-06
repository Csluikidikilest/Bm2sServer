using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Parameter;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleFamily
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Designation { get; set; }
    public string Description { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public List<Article> Articles { get; set; }
    public List<ArticleSubFamily> ArticleSubFamilies { get; set; }
    public List<ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
    public List<ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
    public List<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
    public List<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
  }
}
