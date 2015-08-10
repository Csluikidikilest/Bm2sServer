using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.ArticleFamilyPartnerVat
{
  public class ArticleFamilyPartnerVatsResponse
  {
    public ArticleFamilyPartnerVatsResponse()
    {
      this.ArticleFamilyPartnerVats = new List<Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerVat>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
  }
}
