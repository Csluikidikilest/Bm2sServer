using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.AddressLine
{
  class AddressLinesResponse
  {
    public AddressLinesResponse()
    {
      this.AddressLines = new List<Bm2s.Data.Common.BLL.Partner.AddressLine>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.AddressLine> AddressLines { get; set; }
  }
}
