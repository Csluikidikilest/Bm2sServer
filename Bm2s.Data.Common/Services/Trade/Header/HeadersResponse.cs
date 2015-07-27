using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.Header
{
  public class HeadersResponse
  {
    public HeadersResponse()
    {
      this.Headers = new List<BLL.Trade.Header>();
    }

    public List<BLL.Trade.Header> Headers { get; set; }
  }
}
