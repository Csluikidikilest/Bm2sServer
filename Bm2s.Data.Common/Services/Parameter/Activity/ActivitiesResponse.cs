using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.Activity
{
  public class ActivitiesResponse
  {
    public ActivitiesResponse()
    {
      this.Activities = new List<BLL.Parameter.Activity>();
    }

    public List<BLL.Parameter.Activity> Activities { get; set; }
  }
}
