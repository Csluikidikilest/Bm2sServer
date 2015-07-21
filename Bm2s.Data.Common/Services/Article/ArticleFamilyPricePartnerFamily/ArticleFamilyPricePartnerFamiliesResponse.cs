using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleFamilyPricePartnerFamily
{
  public class ArticleFamilyPricePartnerFamiliesResponse
  {
    public ArticleFamilyPricePartnerFamiliesResponse()
    {
      this.ArticleFamilyPricePartnerFamilies = new List<BLL.Article.ArticleFamilyPricePartnerFamily>();
    }

    public List<BLL.Article.ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
  }
}
