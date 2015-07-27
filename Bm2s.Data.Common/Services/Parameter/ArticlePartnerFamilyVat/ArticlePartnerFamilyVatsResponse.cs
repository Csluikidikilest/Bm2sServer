using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.ArticlePartnerFamilyVat
{
  public class ArticlePartnerFamilyVatsResponse
  {
    public ArticlePartnerFamilyVatsResponse()
    {
      this.ArticlePartnerFamilyVats = new List<BLL.Parameter.ArticlePartnerFamilyVat>();
    }

    public List<BLL.Parameter.ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
  }
}
