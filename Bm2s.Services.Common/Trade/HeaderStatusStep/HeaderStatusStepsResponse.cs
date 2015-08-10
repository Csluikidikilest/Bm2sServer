using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.HeaderStatusStep
{
  public class HeaderStatusStepsResponse
  {
    public HeaderStatusStepsResponse()
    {
      this.HeaderStatusSteps = new List<Bm2s.Data.Common.BLL.Trade.HeaderStatusStep>();
    }

    public List<Bm2s.Data.Common.BLL.Trade.HeaderStatusStep> HeaderStatusSteps { get; set; }
  }
}
