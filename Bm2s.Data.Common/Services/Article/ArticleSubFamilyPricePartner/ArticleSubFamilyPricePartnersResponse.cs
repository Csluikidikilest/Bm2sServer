using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleSubFamilyPricePartner
{
  public class ArticleSubFamilyPricePartnersResponse
  {
    public ArticleSubFamilyPricePartnersResponse()
    {
      this.ArticleSubFamilyPricePartners = new List<BLL.Article.ArticleSubFamilyPricePartner>();
    }

    public List<BLL.Article.ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }
  }
}
