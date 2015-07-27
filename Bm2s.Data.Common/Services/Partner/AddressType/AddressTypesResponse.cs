using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.AddressType
{
  class AddressTypesResponse
  {
    public AddressTypesResponse()
    {
      this.AddressTypes = new List<BLL.Partner.AddressType>();
    }

    public List<BLL.Partner.AddressType> AddressTypes { get; set; }
  }
}
