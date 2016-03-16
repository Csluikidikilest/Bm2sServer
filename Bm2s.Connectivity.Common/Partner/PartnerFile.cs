using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Partner.PartnerFil;

namespace Bm2s.Connectivity.Common.Partner
{
  public class PartnerFile : ClientBase
  {
    public PartnerFile()
      : base()
    {
      this.Request = new PartnerFiles();
      this.Response = new PartnerFilesResponse();
    }

    public PartnerFiles Request { get; set; }

    public PartnerFilesResponse Response { get; set; }

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
