using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.Parameter
{
  [Route("/bm2s/parameters", Verbs = "GET, POST")]
  [Route("/bm2s/parameters/{Ids}", Verbs = "GET")]
  public class Parameters : IReturn<ParametersResponse>
  {
    public Parameters()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Parameter Parameter { get; set; }
  }
}
