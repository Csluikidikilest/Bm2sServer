using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.HeaderOrigin
{
  public class HeaderOriginsResponse
  {
    public HeaderOriginsResponse()
    {
      this.HeaderOrigins = new List<Bm2s.Data.Common.BLL.Trade.HeaderOrigin>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.HeaderOrigin> HeaderOrigins { get; set; }
  }
}
