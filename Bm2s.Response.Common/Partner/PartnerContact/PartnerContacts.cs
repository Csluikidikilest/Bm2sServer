﻿using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Partner.PartnerContact
{
  [Route("/bm2s/partnercontacts", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/partnercontacts/{Ids}", Verbs = "GET")]
  public class PartnerContacts : Request, IReturn<PartnerContactsResponse>
  {
    public PartnerContacts()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public string Email { get; set; }

    public string FaxNumber { get; set; }

    public string FirstName { get; set; }

    public string Function { get; set; }

    public string LastName { get; set; }

    public string MobilePhoneNumber { get; set; }

    public int PartnerId { get; set; }

    public string PhoneNumber { get; set; }

    public Bm2s.Poco.Common.Partner.PartnerContact PartnerContact { get; set; }
  }
}
