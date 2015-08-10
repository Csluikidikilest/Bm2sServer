using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerFamilyVat
{
  [Route("/bm2s/articlepartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlepartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticlePartnerFamilyVats : IReturn<ArticlePartnerFamilyVatsResponse>
  {
    public ArticlePartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerFamilyId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat ArticlePartnerFamilyVat { get; set; }
  }
}
