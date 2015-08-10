using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Period
{
  public class PeriodsResponse
  {
    public PeriodsResponse()
    {
      this.Periods = new List<Bm2s.Data.Common.BLL.Parameter.Period>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.Period> Periods { get; set; }
  }
}
