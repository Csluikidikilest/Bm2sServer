using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.Address
{
  public class AddressesResponse
  {
    public AddressesResponse()
    {
      this.Addresses = new List<Bm2s.Poco.Common.Partner.Address>();
    }

    public List<Bm2s.Poco.Common.Partner.Address> Addresses { get; set; }
  }
}
