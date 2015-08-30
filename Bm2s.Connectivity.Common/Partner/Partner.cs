using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Partner.Partner;

namespace Bm2s.Connectivity.Common.Partner
{
  public class Partner : ClientBase
  {
    public Partner()
      : base()
    {
      this.Request = new Partners();
      this.Response = new PartnersResponse();
    }

    public Partners Request { get; set; }

    public PartnersResponse Response { get; set; }

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
