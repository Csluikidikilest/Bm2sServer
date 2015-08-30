using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.HeaderStatusStep;

namespace Bm2s.Connectivity.Common.Trade
{
  public class HeaderStatusStep : ClientBase
  {
    public HeaderStatusStep()
      : base()
    {
      this.Request = new HeaderStatusSteps();
      this.Response = new HeaderStatusStepsResponse();
    }

    public HeaderStatusSteps Request { get; set; }

    public HeaderStatusStepsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
