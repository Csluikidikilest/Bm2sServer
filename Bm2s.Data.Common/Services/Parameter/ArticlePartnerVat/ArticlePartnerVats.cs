using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.ArticlePartnerVat
{
  [Route("/bm2s/articlepartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlepartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticlePartnerVats : IReturn<ArticlePartnerVatsResponse>
  {
    public ArticlePartnerVats()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.ArticlePartnerVat ArticlePartnerVat { get; set; }
  }
}
