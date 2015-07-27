using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.PartnerFamily
{
  class PartnerFamiliesResponse
  {
    public PartnerFamiliesResponse()
    {
      this.PartnerFamilies = new List<BLL.Partner.PartnerFamily>();
    }

    public List<BLL.Partner.PartnerFamily> PartnerFamilies { get; set; }
  }
}
