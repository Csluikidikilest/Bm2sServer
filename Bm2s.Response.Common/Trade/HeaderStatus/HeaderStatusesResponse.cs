using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Trade.HeaderStatus
{
  public class HeaderStatusesResponse
  {
    public HeaderStatusesResponse()
    {
      this.HeaderStatuses = new List<Bm2s.Poco.Common.Trade.HeaderStatus>();
    }

    public List<Bm2s.Poco.Common.Trade.HeaderStatus> HeaderStatuses { get; set; }
  }
}
