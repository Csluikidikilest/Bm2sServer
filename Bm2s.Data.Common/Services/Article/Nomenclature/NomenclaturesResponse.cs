using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.Nomenclature
{
  public class NomenclaturesResponse
  {
    public NomenclaturesResponse()
    {
      this.Nomenclatures = new List<BLL.Article.Nomenclature>();
    }

    public List<BLL.Article.Nomenclature> Nomenclatures { get; set; }
  }
}
