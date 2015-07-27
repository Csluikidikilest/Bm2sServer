using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.PartnerPartnerFamily
{
  class PartnerPartnerFamiliesResponse
  {
    public PartnerPartnerFamiliesResponse()
    {
      this.PartnerPartnerFamilies = new List<BLL.Partner.PartnerPartnerFamily>();
    }

    public List<BLL.Partner.PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }
  }
}
