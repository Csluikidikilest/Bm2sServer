using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Town
{
  public class TownsResponse
  {
    public TownsResponse()
    {
      this.Towns = new List<BLL.Parameter.Town>();
    }

    public List<BLL.Parameter.Town> Towns { get; set; }
  }
}
