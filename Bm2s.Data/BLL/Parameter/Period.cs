using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class Period
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Interval { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public Unit Unit { get; set; }
  }
}
