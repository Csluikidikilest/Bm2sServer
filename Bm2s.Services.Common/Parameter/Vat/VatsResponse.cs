using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Vat
{
  public class VatsResponse
  {
    public VatsResponse()
    {
      this.Vats = new List<Bm2s.Data.Common.BLL.Parameter.Vat>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.Vat> Vats { get; set; }
  }
}
