using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.InventoryHeader;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class InventoryHeader : ClientBase
  {
    public InventoryHeader()
      : base()
    {
      this.Request = new InventoryHeaders();
      this.Response = new InventoryHeadersResponse();
    }

    public InventoryHeaders Request { get; set; }

    public InventoryHeadersResponse Response { get; set; }

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
