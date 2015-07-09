using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderOrigin
  {
    public DateTime Date { get; set; }
    public Header HeaderParent { get; set; }
    public Header HeaderChild { get; set; }
  }
}
