using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.HeaderFreeReference;

namespace Bm2s.Connectivity.Common.Trade
{
  public class HeaderFreeReference : ClientBase
  {
    public HeaderFreeReference()
      : base()
    {
      this.Request = new HeaderFreeReferences();
      this.Response = new HeaderFreeReferencesResponse();
    }

    public HeaderFreeReferences Request { get; set; }

    public HeaderFreeReferencesResponse Response { get; set; }

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
