using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class CountryCurrency
  {
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public Country Country { get; set; }
    public Unit Unit { get; set; }
  }
}
