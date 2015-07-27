using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.AffairHeader
{
  [Route("/bm2s/affairheaders", Verbs = "GET, POST")]
  [Route("/bm2s/affairheaders/{Ids}", Verbs = "GET")]
  public class AffairHeaders
  {
    public AffairHeaders()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.AffairHeader AffairHeader { get; set; }
  }
}
