using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Trade.HeaderOrigin
{
  public class HeaderOriginsResponse : Response
  {
    public HeaderOriginsResponse()
    {
      this.HeaderOrigins = new List<Bm2s.Poco.Common.Trade.HeaderOrigin>();
    }

    public List<Bm2s.Poco.Common.Trade.HeaderOrigin> HeaderOrigins { get; set; }
  }
}
