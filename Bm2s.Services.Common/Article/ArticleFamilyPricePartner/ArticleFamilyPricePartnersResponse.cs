using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleFamilyPricePartner
{
  public class ArticleFamilyPricePartnersResponse
  {
    public ArticleFamilyPricePartnersResponse()
    {
      this.ArticleFamilyPricePartners = new List<Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner>();
    }

    public List<Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
  }
}
