using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderFreeReference
{
  [Route("/bm2s/headerfreereferences", Verbs = "GET, POST")]
  [Route("/bm2s/headerfreereferences/{Ids}", Verbs = "GET")]
  public class HeaderFreeReferences : IReturn<HeaderFreeReferencesResponse>
  {
    public HeaderFreeReferences()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.HeaderFreeReference HeaderFreeReference { get; set; }
  }
}
