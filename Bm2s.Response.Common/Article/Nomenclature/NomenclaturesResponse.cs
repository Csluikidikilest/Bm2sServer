using System.Collections.Generic;

namespace Bm2s.Response.Common.Article.Nomenclature
{
  public class NomenclaturesResponse
  {
    public NomenclaturesResponse()
    {
      this.Nomenclatures = new List<Bm2s.Poco.Common.Article.Nomenclature>();
    }

    public List<Bm2s.Poco.Common.Article.Nomenclature> Nomenclatures { get; set; }
  }
}
