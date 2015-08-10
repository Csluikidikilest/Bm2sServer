using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Affair
{
  public class AffairsResponse
  {
    public AffairsResponse()
    {
      this.Affairs = new List<Bm2s.Data.Common.BLL.Parameter.Affair>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.Affair> Affairs { get; set; }
  }
}
