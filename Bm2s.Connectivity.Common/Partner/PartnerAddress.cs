using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Partner.PartnerAddress;

namespace Bm2s.Connectivity.Common.Partner
{
  public class PartnerAddress : ClientBase
  {
    public PartnerAddress()
      : base()
    {
      this.Request = new PartnerAddresses();
      this.Response = new PartnerAddressesResponse();
    }

    public PartnerAddresses Request { get; set; }

    public PartnerAddressesResponse Response { get; set; }

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
