using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.AffairHeader
{
  public class AffairHeadersResponse
  {
    public AffairHeadersResponse()
    {
      this.AffairHeaders = new List<Bm2s.Data.Common.BLL.Parameter.AffairHeader>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.AffairHeader> AffairHeaders { get; set; }
  }
}
