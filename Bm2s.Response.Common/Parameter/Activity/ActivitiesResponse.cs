using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.Activity
{
  public class ActivitiesResponse : Response
  {
    public ActivitiesResponse()
    {
      this.Activities = new List<Bm2s.Poco.Common.Parameter.Activity>();
    }

    public List<Bm2s.Poco.Common.Parameter.Activity> Activities { get; set; }
  }
}
