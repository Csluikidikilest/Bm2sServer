using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticlePriceParner
{
  public class ArticlePricePartnersResponse
  {
    public ArticlePricePartnersResponse()
    {
      this.ArticlePricePartners = new List<Bm2s.Data.Common.BLL.Article.ArticlePricePartner>();
    }

    public List<Bm2s.Data.Common.BLL.Article.ArticlePricePartner> ArticlePricePartners { get; set; }
  }
}
