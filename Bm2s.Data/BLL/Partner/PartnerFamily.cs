using System.Collections.Generic;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerFamily
  {
    public List<ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
    public List<ArticlePriceParnerFamily> ArticlePriceParnerFamilys { get; set; }
    public List<ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }
    public List<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
    public List<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
    public List<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
  }
}
