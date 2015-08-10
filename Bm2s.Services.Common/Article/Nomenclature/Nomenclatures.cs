using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.Nomenclature
{
  [Route("/bm2s/nomenclatures", Verbs = "GET, POST")]
  [Route("/bm2s/nomenclatures/{Ids}", Verbs = "GET")]
  public class Nomenclatures : IReturn<NomenclaturesResponse>
  {
    public Nomenclatures()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public string Code { get; set; }

    public string Designation { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Data.Common.BLL.Article.Nomenclature Nomenclature { get; set; }
  }
}
