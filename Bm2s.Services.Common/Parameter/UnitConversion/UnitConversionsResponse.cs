using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.UnitConversion
{
  public class UnitConversionsResponse
  {
    public UnitConversionsResponse()
    {
      this.UnitConversions = new List<Bm2s.Data.Common.BLL.Parameter.UnitConversion>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.UnitConversion> UnitConversions { get; set; }
  }
}
