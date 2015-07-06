using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Sell;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleSubFamily
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Designation { get; set; }
    public string Description { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public ArticleFamily ArticleFamily { get; set; }
    public List<Article> Articles { get; set; }
    public List<ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }
    public List<ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }
    public List<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
    public List<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
    public List<HeaderLine> HeaderLines { get; set; }
  }
}
