using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  public class ArticleSubFamilyPartnerFamilyVatsResponse
  {
    public ArticleSubFamilyPartnerFamilyVatsResponse()
    {
      this.ArticleSubFamilyPartnerFamilyVats = new List<Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
  }
}
