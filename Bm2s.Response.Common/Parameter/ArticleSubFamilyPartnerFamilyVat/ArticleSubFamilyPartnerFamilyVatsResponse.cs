using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  public class ArticleSubFamilyPartnerFamilyVatsResponse : Response
  {
    public ArticleSubFamilyPartnerFamilyVatsResponse()
    {
      this.ArticleSubFamilyPartnerFamilyVats = new List<Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerFamilyVat>();
    }

    public List<Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
  }
}
