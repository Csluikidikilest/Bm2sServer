using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Services.Article.Nomenclature
{
  [Route("/bm2s/nomenclatures", Verbs = "GET, POST")]
  [Route("/bm2s/nomenclatures/{Ids}", Verbs = "GET")]
  public class Nomenclatures : IReturn<NomenclaturesResponse>
  {
    public Nomenclatures()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.Nomenclature Nomenclature { get; set; }
  }
}
