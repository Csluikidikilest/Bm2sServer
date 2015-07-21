using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticlePricePartnerFamily
{
  public class ArticlePricePartnerFamiliesResponse
  {
    public ArticlePricePartnerFamiliesResponse()
    {
      this.ArticlePricePartnerFamilies = new List<BLL.Article.ArticlePricePartnerFamily>();
    }

    public List<BLL.Article.ArticlePricePartnerFamily> ArticlePricePartnerFamilies { get; set; }
  }
}
