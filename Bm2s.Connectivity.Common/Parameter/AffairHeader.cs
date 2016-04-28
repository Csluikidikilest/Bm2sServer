using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.AffairHeader;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class AffairHeader : ClientBase
  {
    public AffairHeader()
      : base()
    {
      this.Request = new AffairHeaders();
      this.Response = new AffairHeadersResponse();
    }

    public AffairHeaders Request { get; set; }

    public AffairHeadersResponse Response { get; set; }

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
