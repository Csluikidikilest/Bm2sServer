using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderStatusStep
{
  public class HeaderStatusStepsResponse
  {
    public HeaderStatusStepsResponse()
    {
      this.HeaderStatusSteps = new List<BLL.Trade.HeaderStatusStep>();
    }

    public List<BLL.Trade.HeaderStatusStep> HeaderStatusSteps { get; set; }
  }
}
