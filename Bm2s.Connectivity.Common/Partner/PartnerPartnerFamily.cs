using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Partner.PartnerPartnerFamily;

namespace Bm2s.Connectivity.Common.Partner
{
  public class PartnerPartnerFamily : ClientBase
  {
    public PartnerPartnerFamily()
      : base()
    {
      this.Request = new PartnerPartnerFamilies();
      this.Response = new PartnerPartnerFamiliesResponse();
    }

    public PartnerPartnerFamilies Request { get; set; }

    public PartnerPartnerFamiliesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
