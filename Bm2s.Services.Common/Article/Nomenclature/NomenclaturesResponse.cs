using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.Nomenclature
{
  public class NomenclaturesResponse
  {
    public NomenclaturesResponse()
    {
      this.Nomenclatures = new List<Bm2s.Data.Common.BLL.Article.Nomenclature>();
    }

    public List<Bm2s.Data.Common.BLL.Article.Nomenclature> Nomenclatures { get; set; }
  }
}
