using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.ArticleSubFamilyPartnerVat
{
  public class ArticleSubFamilyPartnerVatsResponse
  {
    public ArticleSubFamilyPartnerVatsResponse()
    {
      this.ArticleSubFamilyPartnerVats = new List<Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerVat>();
    }

    public List<Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
  }
}
