using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.AddressType
{
  class AddressTypesResponse
  {
    public AddressTypesResponse()
    {
      this.AddressTypes = new List<Bm2s.Data.Common.BLL.Partner.AddressType>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.AddressType> AddressTypes { get; set; }
  }
}
