using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.ArticleFamilyPartnerFamilyVat
{
  public class ArticleFamilyPartnerFamilyVatsResponse : Response
  {
    public ArticleFamilyPartnerFamilyVatsResponse()
    {
      this.ArticleFamilyPartnerFamilyVats = new List<Bm2s.Poco.Common.Parameter.ArticleFamilyPartnerFamilyVat>();
    }

    public List<Bm2s.Poco.Common.Parameter.ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
  }
}
