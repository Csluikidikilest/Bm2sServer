using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleSubFamilyPricePartnerFamily
{
  public class ArticleSubFamilyPricePartnerFamiliesResponse
  {
    public ArticleSubFamilyPricePartnerFamiliesResponse()
    {
      this.ArticleSubFamilyPricePartnerFamilies = new List<BLL.Article.ArticleSubFamilyPricePartnerFamily>();
    }

    public List<BLL.Article.ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }
  }
}
