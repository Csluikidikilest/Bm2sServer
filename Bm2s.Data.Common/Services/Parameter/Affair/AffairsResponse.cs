using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Affair
{
  public class AffairsResponse
  {
    public AffairsResponse()
    {
      this.Affairs = new List<BLL.Parameter.Affair>();
    }

    public List<BLL.Parameter.Affair> Affairs { get; set; }
  }
}
