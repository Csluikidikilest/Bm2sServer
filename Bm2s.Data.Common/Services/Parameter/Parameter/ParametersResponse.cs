using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Parameter
{
  public class ParametersResponse
  {
    public ParametersResponse()
    {
      this.Parameters = new List<BLL.Parameter.Parameter>();
    }

    public List<BLL.Parameter.Parameter> Parameters { get; set; }
  }
}
