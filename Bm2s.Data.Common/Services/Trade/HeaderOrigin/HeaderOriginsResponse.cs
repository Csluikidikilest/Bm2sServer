using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderOrigin
{
  public class HeaderOriginsResponse
  {
    public HeaderOriginsResponse()
    {
      this.HeaderOrigins = new List<BLL.Trade.HeaderOrigin>();
    }

    public List<BLL.Trade.HeaderOrigin> HeaderOrigins { get; set; }
  }
}
