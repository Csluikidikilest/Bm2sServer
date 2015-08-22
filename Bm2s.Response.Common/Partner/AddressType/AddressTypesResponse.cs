using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.AddressType
{
  class AddressTypesResponse
  {
    public AddressTypesResponse()
    {
      this.AddressTypes = new List<Bm2s.Poco.Common.Partner.AddressType>();
    }

    public List<Bm2s.Poco.Common.Partner.AddressType> AddressTypes { get; set; }
  }
}
