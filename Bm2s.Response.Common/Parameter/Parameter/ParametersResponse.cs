using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Parameter
{
  public class ParametersResponse : Response
  {
    public ParametersResponse()
    {
      this.Parameters = new List<Bm2s.Poco.Common.Parameter.Parameter>();
    }

    public List<Bm2s.Poco.Common.Parameter.Parameter> Parameters { get; set; }
  }
}
