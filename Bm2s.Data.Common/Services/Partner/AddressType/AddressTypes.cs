﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.AddressType
{
  [Route("/bm2s/addresstypes", Verbs = "GET, POST")]
  [Route("/bm2s/addresstypes/{Ids}", Verbs = "GET")]
  public class AddressTypes : IReturn<AddressTypesResponse>
  {
    public AddressTypes()
    {
      this.Ids = new List<int>();
    }
    public string Code { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public BLL.Partner.AddressType AddressType { get; set; }
  }
}
