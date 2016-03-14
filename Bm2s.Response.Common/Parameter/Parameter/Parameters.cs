using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.Parameter
{
  [Route("/bm2s/parameters", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/parameters/{Ids}", Verbs = "GET")]
  public class Parameters : Request, IReturn<ParametersResponse>
  {
    public Parameters()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public Bm2s.Poco.Common.Parameter.Parameter Parameter { get; set; }
  }
}
