using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderLineType
{
  public class HeaderLineTypesResponse
  {
    public HeaderLineTypesResponse()
    {
      this.HeaderLineTypes = new List<BLL.Trade.HeaderLineType>();
    }

    public List<BLL.Trade.HeaderLineType> HeaderLineTypes { get; set; }
  }
}
