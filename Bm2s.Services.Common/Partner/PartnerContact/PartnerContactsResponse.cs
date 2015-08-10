using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.PartnerContact
{
  class PartnerContactsResponse
  {
    public PartnerContactsResponse()
    {
      this.PartnerContacts = new List<Bm2s.Data.Common.BLL.Partner.PartnerContact>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.PartnerContact> PartnerContacts { get; set; }
  }
}
