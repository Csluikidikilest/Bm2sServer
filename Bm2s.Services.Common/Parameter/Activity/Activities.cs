using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Activity
{
  [Route("/bm2s/activities", Verbs = "GET, POST")]
  [Route("/bm2s/activities/{Ids}", Verbs = "GET")]
  public class Activities : IReturn<ActivitiesResponse>
  {
    public Activities()
    {
      this.Ids = new List<int>();
    }

    public string CompanyName { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Data.Common.BLL.Parameter.Activity Activity { get; set; }
  }
}
