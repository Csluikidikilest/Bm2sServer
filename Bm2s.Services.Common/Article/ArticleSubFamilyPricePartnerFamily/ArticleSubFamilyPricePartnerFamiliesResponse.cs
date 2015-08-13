using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleSubFamilyPricePartnerFamily
{
  public class ArticleSubFamilyPricePartnerFamiliesResponse
  {
    public ArticleSubFamilyPricePartnerFamiliesResponse()
    {
      this.ArticleSubFamilyPricePartnerFamilies = new List<Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartnerFamily>();
    }

    public List<Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }
  }
}
