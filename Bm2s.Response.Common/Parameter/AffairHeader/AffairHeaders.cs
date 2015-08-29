using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.AffairHeader
{
  [Route("/bm2s/affairheaders", Verbs = "GET, POST")]
  [Route("/bm2s/affairheaders/{Ids}", Verbs = "GET")]
  public class AffairHeaders : Request, IReturn<AffairHeadersResponse>
  {
    public AffairHeaders()
    {
      this.Ids = new List<int>();
    }

    public int AffairId { get; set; }

    public int HeaderId { get; set; }

    public Bm2s.Poco.Common.Parameter.AffairHeader AffairHeader { get; set; }
  }
}
