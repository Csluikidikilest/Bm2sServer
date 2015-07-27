using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.Address
{
  class AddressesResponse
  {
    public AddressesResponse()
    {
      this.Addresses = new List<BLL.Partner.Address>();
    }

    public List<BLL.Partner.Address> Addresses { get; set; }
  }
}
