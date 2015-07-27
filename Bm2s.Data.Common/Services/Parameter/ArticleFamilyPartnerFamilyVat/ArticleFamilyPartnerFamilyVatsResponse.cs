using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.ArticleFamilyPartnerFamilyVat
{
  public class ArticleFamilyPartnerFamilyVatsResponse
  {
    public ArticleFamilyPartnerFamilyVatsResponse()
    {
      this.ArticleFamilyPartnerFamilyVats = new List<BLL.Parameter.ArticleFamilyPartnerFamilyVat>();
    }

    public List<BLL.Parameter.ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
  }
}
