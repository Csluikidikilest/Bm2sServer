using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerVat
{
  public class ArticlePartnerVatsResponse
  {
    public ArticlePartnerVatsResponse()
    {
      this.ArticlePartnerVats = new List<Bm2s.Data.Common.BLL.Parameter.ArticlePartnerVat>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.ArticlePartnerVat> ArticlePartnerVats { get; set; }
  }
}
