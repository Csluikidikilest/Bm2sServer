using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  [Route("/bm2s/articlesubfamilypartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPartnerFamilyVats : IReturn<ArticleSubFamilyPartnerFamilyVatsResponse>
  {
    public ArticleSubFamilyPartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleSubFamilyId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerFamilyId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat ArticleSubFamilyPartnerFamilyVat { get; set; }
  }
}
