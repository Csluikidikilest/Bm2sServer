using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticleFamilyPricePartner
{
  public class ArticleFamilyPricePartnersResponse : Response
  {
    public ArticleFamilyPricePartnersResponse()
    {
      this.ArticleFamilyPricePartners = new List<Bm2s.Poco.Common.Article.ArticleFamilyPricePartner>();
    }

    public List<Bm2s.Poco.Common.Article.ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
  }
}
