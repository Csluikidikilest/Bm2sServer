﻿using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.PartnerContact
{
  public class PartnerContactsResponse : Response
  {
    public PartnerContactsResponse()
    {
      this.PartnerContacts = new List<Bm2s.Poco.Common.Partner.PartnerContact>();
    }

    public List<Bm2s.Poco.Common.Partner.PartnerContact> PartnerContacts { get; set; }
  }
}
