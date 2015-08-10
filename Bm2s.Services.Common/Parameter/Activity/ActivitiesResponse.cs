using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.Activity
{
  public class ActivitiesResponse
  {
    public ActivitiesResponse()
    {
      this.Activities = new List<Bm2s.Data.Common.BLL.Parameter.Activity>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.Activity> Activities { get; set; }
  }
}
