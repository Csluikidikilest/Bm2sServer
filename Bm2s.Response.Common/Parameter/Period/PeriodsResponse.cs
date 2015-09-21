using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Period
{
  public class PeriodsResponse : Response
  {
    public PeriodsResponse()
    {
      this.Periods = new List<Bm2s.Poco.Common.Parameter.Period>();
    }

    public List<Bm2s.Poco.Common.Parameter.Period> Periods { get; set; }
  }
}
