using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.PartnerPartnerFamily
{
  public class PartnerPartnerFamiliesResponse : Response
  {
    public PartnerPartnerFamiliesResponse()
    {
      this.PartnerPartnerFamilies = new List<Bm2s.Poco.Common.Partner.PartnerPartnerFamily>();
    }

    public List<Bm2s.Poco.Common.Partner.PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }
  }
}
