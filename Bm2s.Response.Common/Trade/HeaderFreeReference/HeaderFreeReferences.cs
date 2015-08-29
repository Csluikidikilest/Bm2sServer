using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.HeaderFreeReference
{
  [Route("/bm2s/headerfreereferences", Verbs = "GET, POST")]
  [Route("/bm2s/headerfreereferences/{Ids}", Verbs = "GET")]
  public class HeaderFreeReferences : Request, IReturn<HeaderFreeReferencesResponse>
  {
    public HeaderFreeReferences()
    {
      this.Ids = new List<int>();
    }

    public int HeaderStatusId { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderFreeReference HeaderFreeReference { get; set; }
  }
}
