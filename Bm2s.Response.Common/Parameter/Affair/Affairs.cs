using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.Affair
{
  [Route("/bm2s/affairs", Verbs = "GET, POST")]
  [Route("/bm2s/affairs/{Ids}", Verbs = "GET")]
  public class Affairs : Request, IReturn<AffairsResponse>
  {
    public Affairs()
    {
      this.Ids = new List<int>();
    }

    public int ActivityId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public int UserId { get; set; }

    public Bm2s.Poco.Common.Parameter.Affair Affair { get; set; }
  }
}
