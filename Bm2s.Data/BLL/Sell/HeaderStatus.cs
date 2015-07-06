using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Sell
{
  public class HeaderStatus
  {
    public int Id { get; private set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public List<HeaderStatusStep> HeaderStatusStepParents { get; set; }
    public List<HeaderStatusStep> HeaderStatusStepChildren { get; set; }
  }
}
