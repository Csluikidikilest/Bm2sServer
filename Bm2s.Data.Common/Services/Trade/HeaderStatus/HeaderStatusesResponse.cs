using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderStatus
{
  public class HeaderStatusesResponse
  {
    public HeaderStatusesResponse()
    {
      this.HeaderStatuses = new List<BLL.Trade.HeaderStatus>();
    }

    public List<BLL.Trade.HeaderStatus> HeaderStatuses { get; set; }
  }
}
