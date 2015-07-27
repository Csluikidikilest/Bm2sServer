using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderLine
{
  public class HeaderLinesResponse
  {
    public HeaderLinesResponse()
    {
      this.HeaderLines = new List<BLL.Trade.HeaderLine>();
    }

    public List<BLL.Trade.HeaderLine> HeaderLines { get; set; }
  }
}
