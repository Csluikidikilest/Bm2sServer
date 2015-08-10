using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.Partner
{
  class PartnersResponse
  {
    public PartnersResponse()
    {
      this.Partners = new List<Bm2s.Data.Common.BLL.Partner.Partner>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.Partner> Partners { get; set; }
  }
}
