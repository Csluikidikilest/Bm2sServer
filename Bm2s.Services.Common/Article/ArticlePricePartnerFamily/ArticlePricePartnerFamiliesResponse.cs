using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticlePricePartnerFamily
{
  public class ArticlePricePartnerFamiliesResponse
  {
    public ArticlePricePartnerFamiliesResponse()
    {
      this.ArticlePricePartnerFamilies = new List<Bm2s.Data.Common.BLL.Article.ArticlePricePartnerFamily>();
    }

    public List<Bm2s.Data.Common.BLL.Article.ArticlePricePartnerFamily> ArticlePricePartnerFamilies { get; set; }
  }
}
