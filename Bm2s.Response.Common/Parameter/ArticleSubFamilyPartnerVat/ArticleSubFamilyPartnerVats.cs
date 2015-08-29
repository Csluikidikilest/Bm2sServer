using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.ArticleSubFamilyPartnerVat
{
  [Route("/bm2s/articlesubfamilypartnervats", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypartnervats/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPartnerVats : Request, IReturn<ArticleSubFamilyPartnerVatsResponse>
  {
    public ArticleSubFamilyPartnerVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleSubFamilyId { get; set; }

    public int PartnerId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerVat ArticleSubFamilyPartnerVat { get; set; }
  }
}
