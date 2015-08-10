using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.PartnerFamily
{
  class PartnerFamiliesResponse
  {
    public PartnerFamiliesResponse()
    {
      this.PartnerFamilies = new List<Bm2s.Data.Common.BLL.Partner.PartnerFamily>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.PartnerFamily> PartnerFamilies { get; set; }
  }
}
