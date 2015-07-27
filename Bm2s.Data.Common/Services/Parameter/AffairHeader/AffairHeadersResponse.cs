using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.AffairHeader
{
  public class AffairHeadersResponse
  {
    public AffairHeadersResponse()
    {
      this.AffairHeaders = new List<BLL.Parameter.AffairHeader>();
    }

    public List<BLL.Parameter.AffairHeader> AffairHeaders { get; set; }
  }
}
