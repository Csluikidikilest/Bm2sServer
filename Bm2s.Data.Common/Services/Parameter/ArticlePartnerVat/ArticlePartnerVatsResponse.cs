using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.ArticlePartnerVat
{
  public class ArticlePartnerVatsResponse
  {
    public ArticlePartnerVatsResponse()
    {
      this.ArticlePartnerVats = new List<BLL.Parameter.ArticlePartnerVat>();
    }

    public List<BLL.Parameter.ArticlePartnerVat> ArticlePartnerVats { get; set; }
  }
}
