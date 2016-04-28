using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  [Route("/bm2s/articlesubfamilypartnerfamilyvats", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/articlesubfamilypartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPartnerFamilyVats : Request, IReturn<ArticleSubFamilyPartnerFamilyVatsResponse>
  {
    public ArticleSubFamilyPartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleSubFamilyId { get; set; }

    public int PartnerFamilyId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerFamilyVat ArticleSubFamilyPartnerFamilyVat { get; set; }
  }
}
