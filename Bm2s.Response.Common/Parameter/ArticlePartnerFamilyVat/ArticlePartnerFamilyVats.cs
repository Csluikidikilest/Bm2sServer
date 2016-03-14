using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.ArticlePartnerFamilyVat
{
  [Route("/bm2s/articlepartnerfamilyvats", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/articlepartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticlePartnerFamilyVats : Request, IReturn<ArticlePartnerFamilyVatsResponse>
  {
    public ArticlePartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public int PartnerFamilyId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Poco.Common.Parameter.ArticlePartnerFamilyVat ArticlePartnerFamilyVat { get; set; }
  }
}
