using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.HeaderFreeReference
{
  [Route("/bm2s/headerfreereferences", Verbs = "GET, POST")]
  [Route("/bm2s/headerfreereferences/{Ids}", Verbs = "GET")]
  public class HeaderFreeReferences : IReturn<HeaderFreeReferencesResponse>
  {
    public HeaderFreeReferences()
    {
      this.Ids = new List<int>();
    }

    public int HeaderStatusId { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderFreeReference HeaderFreeReference { get; set; }
  }
}
