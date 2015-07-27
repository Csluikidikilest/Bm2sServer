using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Unit
{
  public class UnitsResponse
  {
    public UnitsResponse()
    {
      this.Units = new List<BLL.Parameter.Unit>();
    }

    public List<BLL.Parameter.Unit> Units { get; set; }
  }
}
