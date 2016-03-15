using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Response.Common.Article.Nomenclature
{
  [Route("/bm2s/nomenclatures")]
  [Route("/bm2s/nomenclatures/{Ids}", Verbs = "GET")]
  public class Nomenclatures : Request, IReturn<NomenclaturesResponse>
  {
    public Nomenclatures()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public Bm2s.Poco.Common.Article.Nomenclature Nomenclature { get; set; }
  }
}
