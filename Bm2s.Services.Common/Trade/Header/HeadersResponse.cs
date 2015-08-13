using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.Header
{
  public class HeadersResponse
  {
    public HeadersResponse()
    {
      this.Headers = new List<Bm2s.Poco.Common.Trade.Header>();
    }

    public List<Bm2s.Poco.Common.Trade.Header> Headers { get; set; }
  }
}
