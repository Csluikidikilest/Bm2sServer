using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Period
{
  public class PeriodsResponse
  {
    public PeriodsResponse()
    {
      this.Periods = new List<BLL.Parameter.Period>();
    }

    public List<BLL.Parameter.Period> Periods { get; set; }
  }
}
