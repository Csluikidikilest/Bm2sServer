using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.UnitConversion
{
  public class UnitConversionsResponse
  {
    public UnitConversionsResponse()
    {
      this.UnitConversions = new List<BLL.Parameter.UnitConversion>();
    }

    public List<BLL.Parameter.UnitConversion> UnitConversions { get; set; }
  }
}
