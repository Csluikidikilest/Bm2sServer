using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.Address
{
  class AddressesResponse
  {
    public AddressesResponse()
    {
      this.Addresses = new List<Bm2s.Data.Common.BLL.Partner.Address>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.Address> Addresses { get; set; }
  }
}
