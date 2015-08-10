using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.ArticleFamilyPartnerFamilyVat
{
  public class ArticleFamilyPartnerFamilyVatsResponse
  {
    public ArticleFamilyPartnerFamilyVatsResponse()
    {
      this.ArticleFamilyPartnerFamilyVats = new List<Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
  }
}
