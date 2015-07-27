using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.Partner
{
  class PartnersResponse
  {
    public PartnersResponse()
    {
      this.Partners = new List<BLL.Partner.Partner>();
    }

    public List<BLL.Partner.Partner> Partners { get; set; }
  }
}
