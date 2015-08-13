using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.HeaderStatusStep
{
  [Route("/bm2s/headerstatussteps", Verbs = "GET, POST")]
  [Route("/bm2s/headerstatussteps/{Ids}", Verbs = "GET")]
  public class HeaderStatusSteps : IReturn<HeaderStatusStepsResponse>
  {
    public HeaderStatusSteps()
    {
      this.Ids = new List<int>();
    }

    public int HeaderStatusChildId { get; set; }

    public int HeaderStatusParentId { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderStatusStep HeaderStatusStep { get; set; }
  }
}
