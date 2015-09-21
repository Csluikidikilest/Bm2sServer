using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticlePricePartnerFamily
{
  public class ArticlePricePartnerFamiliesResponse : Response
  {
    public ArticlePricePartnerFamiliesResponse()
    {
      this.ArticlePricePartnerFamilies = new List<Bm2s.Poco.Common.Article.ArticlePricePartnerFamily>();
    }

    public List<Bm2s.Poco.Common.Article.ArticlePricePartnerFamily> ArticlePricePartnerFamilies { get; set; }
  }
}
