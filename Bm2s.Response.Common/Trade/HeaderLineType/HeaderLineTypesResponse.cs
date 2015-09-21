using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Trade.HeaderLineType
{
  public class HeaderLineTypesResponse : Response
  {
    public HeaderLineTypesResponse()
    {
      this.HeaderLineTypes = new List<Bm2s.Poco.Common.Trade.HeaderLineType>();
    }

    public List<Bm2s.Poco.Common.Trade.HeaderLineType> HeaderLineTypes { get; set; }
  }
}
