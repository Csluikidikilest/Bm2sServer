using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleFamilyPricePartner
{
  public class ArticleFamilyPricePartnersResponse
  {
    public ArticleFamilyPricePartnersResponse()
    {
      this.ArticleFamilyPricePartners = new List<BLL.Article.ArticleFamilyPricePartner>();
    }

    public List<BLL.Article.ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
  }
}
