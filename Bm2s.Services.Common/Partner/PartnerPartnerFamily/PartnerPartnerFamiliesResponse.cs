using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.PartnerPartnerFamily
{
  class PartnerPartnerFamiliesResponse
  {
    public PartnerPartnerFamiliesResponse()
    {
      this.PartnerPartnerFamilies = new List<Bm2s.Data.Common.BLL.Partner.PartnerPartnerFamily>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }
  }
}
