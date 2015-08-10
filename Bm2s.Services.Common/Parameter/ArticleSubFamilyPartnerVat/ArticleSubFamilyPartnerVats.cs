using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.ArticleSubFamilyPartnerVat
{
  [Route("/bm2s/articlesubfamilypartnervats", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypartnervats/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPartnerVats : IReturn<ArticleSubFamilyPartnerVatsResponse>
  {
    public ArticleSubFamilyPartnerVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleSubFamilyId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerVat ArticleSubFamilyPartnerVat { get; set; }
  }
}
