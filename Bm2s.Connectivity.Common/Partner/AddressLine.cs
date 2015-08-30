using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Partner.AddressLine;

namespace Bm2s.Connectivity.Common.Partner
{
  public class AddressLine : ClientBase
  {
    public AddressLine()
      : base()
    {
      this.Request = new AddressLines();
      this.Response = new AddressLinesResponse();
    }

    public AddressLines Request { get; set; }

    public AddressLinesResponse Response { get; set; }

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
