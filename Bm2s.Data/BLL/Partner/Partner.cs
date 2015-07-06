using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;

namespace Bm2s.Data.BLL.Partner
{
  public class Partner
  {
    public List<ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
    public List<ArticlePriceParner> ArticlePriceParners { get; set; }
    public List<ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }
    public List<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
    public List<ArticlePartnerVat> ArticlePartnerVats { get; set; }
    public List<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
  }
}
