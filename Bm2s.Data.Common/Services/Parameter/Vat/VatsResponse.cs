using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Vat
{
  public class VatsResponse
  {
    public VatsResponse()
    {
      this.Vats = new List<BLL.Parameter.Vat>();
    }

    public List<BLL.Parameter.Vat> Vats { get; set; }
  }
}
