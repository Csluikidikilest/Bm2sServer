using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.Partner
{
  [Route("/bm2s/partners", Verbs = "GET, POST")]
  [Route("/bm2s/partners/{Ids}", Verbs = "GET")]
  public class Partners : IReturn<PartnersResponse>
  {
    public Partners()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Partner.Partner Partner { get; set; }
  }
}
