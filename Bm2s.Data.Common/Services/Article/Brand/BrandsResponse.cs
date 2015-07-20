using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.Brand
{
  public class BrandsResponse
  {
    public BrandsResponse()
    {
      this.Brands = new List<BLL.Article.Brand>();
    }

    public List<BLL.Article.Brand> Brands { get; set; }
  }
}
