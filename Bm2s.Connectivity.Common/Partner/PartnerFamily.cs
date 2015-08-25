using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Partner.PartnerFamily;

namespace Bm2s.Connectivity.Common.Partner
{
  public class PartnerFamily : ClientBase
  {
    public PartnerFamily()
      : base()
    {
      this.Request = new PartnerFamilies();
      this.Response = new PartnerFamiliesResponse();
    }

    public PartnerFamilies Request { get; set; }

    public PartnerFamiliesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
