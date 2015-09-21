using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.ArticlePartnerVat
{
  public class ArticlePartnerVatsResponse : Response
  {
    public ArticlePartnerVatsResponse()
    {
      this.ArticlePartnerVats = new List<Bm2s.Poco.Common.Parameter.ArticlePartnerVat>();
    }

    public List<Bm2s.Poco.Common.Parameter.ArticlePartnerVat> ArticlePartnerVats { get; set; }
  }
}
