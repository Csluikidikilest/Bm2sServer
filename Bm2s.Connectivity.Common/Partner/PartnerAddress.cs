using Bm2s.Connectivity.Utils;
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
  }
}
