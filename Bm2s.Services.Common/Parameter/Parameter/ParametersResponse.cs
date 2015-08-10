using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Parameter
{
  public class ParametersResponse
  {
    public ParametersResponse()
    {
      this.Parameters = new List<Bm2s.Data.Common.BLL.Parameter.Parameter>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.Parameter> Parameters { get; set; }
  }
}
