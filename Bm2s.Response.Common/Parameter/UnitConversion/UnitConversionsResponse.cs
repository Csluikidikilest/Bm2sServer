using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.UnitConversion
{
  public class UnitConversionsResponse : Response
  {
    public UnitConversionsResponse()
    {
      this.UnitConversions = new List<Bm2s.Poco.Common.Parameter.UnitConversion>();
    }

    public List<Bm2s.Poco.Common.Parameter.UnitConversion> UnitConversions { get; set; }
  }
}
