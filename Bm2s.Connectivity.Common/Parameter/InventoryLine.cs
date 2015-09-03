using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.InventoryLine;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class InventoryLine : ClientBase
  {
    public InventoryLine()
      : base()
    {
      this.Request = new InventoryLines();
      this.Response = new InventoryLinesResponse();
    }

    public InventoryLines Request { get; set; }

    public InventoryLinesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    public void Post()
    {
      this.Response = this.ConnectorHelper.Post(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
