using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Period
{
  public class PeriodsResponse
  {
    public PeriodsResponse()
    {
      this.Periods = new List<Bm2s.Poco.Common.Parameter.Period>();
    }

    public List<Bm2s.Poco.Common.Parameter.Period> Periods { get; set; }
  }
}
