using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.HeaderStatus
{
  public class HeaderStatusesResponse
  {
    public HeaderStatusesResponse()
    {
      this.HeaderStatuses = new List<Bm2s.Data.Common.BLL.Trade.HeaderStatus>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.HeaderStatus> HeaderStatuses { get; set; }
  }
}
