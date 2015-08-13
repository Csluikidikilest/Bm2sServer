using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerFamilyVat
{
  public class ArticlePartnerFamilyVatsResponse
  {
    public ArticlePartnerFamilyVatsResponse()
    {
      this.ArticlePartnerFamilyVats = new List<Bm2s.Poco.Common.Parameter.ArticlePartnerFamilyVat>();
    }

    public List<Bm2s.Poco.Common.Parameter.ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
  }
}
