using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Affair
{
  public class AffairsResponse
  {
    public AffairsResponse()
    {
      this.Affairs = new List<Bm2s.Poco.Common.Parameter.Affair>();
    }

    public List<Bm2s.Poco.Common.Parameter.Affair> Affairs { get; set; }
  }
}
