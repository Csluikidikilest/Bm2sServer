using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.AffairHeader
{
  public class AffairHeadersResponse : Response
  {
    public AffairHeadersResponse()
    {
      this.AffairHeaders = new List<Bm2s.Poco.Common.Parameter.AffairHeader>();
    }

    public List<Bm2s.Poco.Common.Parameter.AffairHeader> AffairHeaders { get; set; }
  }
}
