using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.PartnerContact
{
  class PartnerContactsResponse
  {
    public PartnerContactsResponse()
    {
      this.PartnerContacts = new List<BLL.Partner.PartnerContact>();
    }

    public List<BLL.Partner.PartnerContact> PartnerContacts { get; set; }
  }
}
