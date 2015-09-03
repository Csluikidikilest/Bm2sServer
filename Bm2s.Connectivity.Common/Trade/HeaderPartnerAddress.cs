using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Trade.HeaderPartnerAddress;

namespace Bm2s.Connectivity.Common.Trade
{
  public class HeaderPartnerAddress : ClientBase
  {
    public HeaderPartnerAddress()
      : base()
    {
      this.Request = new HeaderPartnerAddresses();
      this.Response = new HeaderPartnerAddressesResponse();
    }

    public HeaderPartnerAddresses Request { get; set; }

    public HeaderPartnerAddressesResponse Response { get; set; }

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
