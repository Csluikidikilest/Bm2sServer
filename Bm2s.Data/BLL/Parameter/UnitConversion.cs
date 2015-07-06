using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class UnitConversion
  {
    public int Multiplier { get; set; }
    public Unit Child { get; set; }
    public Unit Parent { get; set; }
  }
}
