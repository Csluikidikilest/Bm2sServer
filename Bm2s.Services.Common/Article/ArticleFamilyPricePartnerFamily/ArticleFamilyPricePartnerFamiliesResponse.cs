using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleFamilyPricePartnerFamily
{
  public class ArticleFamilyPricePartnerFamiliesResponse
  {
    public ArticleFamilyPricePartnerFamiliesResponse()
    {
      this.ArticleFamilyPricePartnerFamilies = new List<Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartnerFamily>();
    }

    public List<Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
  }
}
