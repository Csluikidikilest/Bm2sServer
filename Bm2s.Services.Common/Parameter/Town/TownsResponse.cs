using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Town
{
  public class TownsResponse
  {
    public TownsResponse()
    {
      this.Towns = new List<Bm2s.Poco.Common.Parameter.Town>();
    }

    public List<Bm2s.Poco.Common.Parameter.Town> Towns { get; set; }
  }
}
