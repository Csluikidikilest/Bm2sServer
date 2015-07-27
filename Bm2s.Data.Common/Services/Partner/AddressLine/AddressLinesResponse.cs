using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.AddressLine
{
  class AddressLinesResponse
  {
    public AddressLinesResponse()
    {
      this.AddressLines = new List<BLL.Partner.AddressLine>();
    }

    public List<BLL.Partner.AddressLine> AddressLines { get; set; }
  }
}
