﻿using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Activity
{
  [Route("/bm2s/activities", Verbs = "GET, POST")]
  [Route("/bm2s/activities/{Ids}", Verbs = "GET")]
  public class Activities : IReturn<ActivitiesResponse>
  {
    public Activities()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Activity Activity { get; set; }
  }
}
