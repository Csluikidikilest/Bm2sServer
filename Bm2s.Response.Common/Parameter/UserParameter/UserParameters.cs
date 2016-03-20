using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.UserParameter
{
  [Route("/bm2s/userparameters", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/userparameters/{Ids}", Verbs = "GET")]
  public class UserParameters : Request, IReturn<UserParametersResponse>
  {
    public UserParameters()
    {
      this.Ids = new List<int>();
    }

    public int ParameterId { get; set; }

    public Bm2s.Poco.Common.Parameter.UserParameter UserParameter { get; set; }
  }
}
