using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  public class ArticleSubFamilyPartnerFamilyVatsResponse
  {
    public ArticleSubFamilyPartnerFamilyVatsResponse()
    {
      this.ArticleSubFamilyPartnerFamilyVats = new List<BLL.Parameter.ArticleSubFamilyPartnerFamilyVat>();
    }

    public List<BLL.Parameter.ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
  }
}
