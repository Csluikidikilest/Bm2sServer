using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Parameter.Activity;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Activity : ClientBase
  {
    public Activity()
      : base()
    {
      this.Request = new Activities();
      this.Response = new ActivitiesResponse();
    }

    public Activities Request { get; set; }

    public ActivitiesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
