using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.ArticleFamilyPartnerVat
{
  public class ArticleFamilyPartnerVatsResponse
  {
    public ArticleFamilyPartnerVatsResponse()
    {
      this.ArticleFamilyPartnerVats = new List<BLL.Parameter.ArticleFamilyPartnerVat>();
    }

    public List<BLL.Parameter.ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
  }
}
