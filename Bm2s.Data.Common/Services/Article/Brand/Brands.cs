using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.Brand
{
  [Route("/bm2s/brands", Verbs = "GET, POST")]
  [Route("/bm2s/brands/{Ids}", Verbs = "GET")]
  public class Brands : IReturn<BrandsResponse>
  {
    public Brands()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.Brand Brand { get; set; }
  }
}
