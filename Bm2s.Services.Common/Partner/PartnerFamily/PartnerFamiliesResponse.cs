using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.PartnerFamily
{
  class PartnerFamiliesResponse
  {
    public PartnerFamiliesResponse()
    {
      this.PartnerFamilies = new List<Bm2s.Poco.Common.Partner.PartnerFamily>();
    }

    public List<Bm2s.Poco.Common.Partner.PartnerFamily> PartnerFamilies { get; set; }
  }
}
