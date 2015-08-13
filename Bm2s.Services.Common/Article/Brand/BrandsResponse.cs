using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.Brand
{
  public class BrandsResponse
  {
    public BrandsResponse()
    {
      this.Brands = new List<Bm2s.Poco.Common.Article.Brand>();
    }

    public List<Bm2s.Poco.Common.Article.Brand> Brands { get; set; }
  }
}
