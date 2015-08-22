using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Vat
{
  public class VatsResponse
  {
    public VatsResponse()
    {
      this.Vats = new List<Bm2s.Poco.Common.Parameter.Vat>();
    }

    public List<Bm2s.Poco.Common.Parameter.Vat> Vats { get; set; }
  }
}
