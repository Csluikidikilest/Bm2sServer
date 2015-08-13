using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.HeaderLine
{
  public class HeaderLinesResponse
  {
    public HeaderLinesResponse()
    {
      this.HeaderLines = new List<Bm2s.Poco.Common.Trade.HeaderLine>();
    }

    public List<Bm2s.Poco.Common.Trade.HeaderLine> HeaderLines { get; set; }
  }
}
