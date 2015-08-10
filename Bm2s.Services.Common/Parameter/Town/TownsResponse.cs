using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Town
{
  public class TownsResponse
  {
    public TownsResponse()
    {
      this.Towns = new List<Bm2s.Data.Common.BLL.Parameter.Town>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.Town> Towns { get; set; }
  }
}
