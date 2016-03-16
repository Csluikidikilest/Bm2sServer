using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.HeaderFile;

namespace Bm2s.Connectivity.Common.Trade
{
  public class HeaderFile : ClientBase
  {
    public HeaderFile()
      : base()
    {
      this.Request = new HeaderFiles();
      this.Response = new HeaderFilesResponse();
    }

    public HeaderFiles Request { get; set; }

    public HeaderFilesResponse Response { get; set; }

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

    public void Delete()
    {
      this.Response = this.ConnectorHelper.Delete(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}
