using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.ArticleSubFamilyPartnerVat
{
  public class ArticleSubFamilyPartnerVatsResponse
  {
    public ArticleSubFamilyPartnerVatsResponse()
    {
      this.ArticleSubFamilyPartnerVats = new List<BLL.Parameter.ArticleSubFamilyPartnerVat>();
    }

    public List<BLL.Parameter.ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
  }
}
