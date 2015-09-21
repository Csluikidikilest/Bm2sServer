using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Affair
{
  public class AffairsResponse : Response
  {
    public AffairsResponse()
    {
      this.Affairs = new List<Bm2s.Poco.Common.Parameter.Affair>();
    }

    public List<Bm2s.Poco.Common.Parameter.Affair> Affairs { get; set; }
  }
}
