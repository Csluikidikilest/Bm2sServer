using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticlePriceParner
{
  public class ArticlePricePartnersResponse
  {
    public ArticlePricePartnersResponse()
    {
      this.ArticlePricePartners = new List<BLL.Article.ArticlePricePartner>();
    }

    public List<BLL.Article.ArticlePricePartner> ArticlePricePartners { get; set; }
  }
}
