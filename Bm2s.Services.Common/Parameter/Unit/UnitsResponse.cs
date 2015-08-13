using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Unit
{
  public class UnitsResponse
  {
    public UnitsResponse()
    {
      this.Units = new List<Bm2s.Poco.Common.Parameter.Unit>();
    }

    public List<Bm2s.Poco.Common.Parameter.Unit> Units { get; set; }
  }
}
