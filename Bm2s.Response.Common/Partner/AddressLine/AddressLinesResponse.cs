using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.AddressLine
{
  public class AddressLinesResponse : Response
  {
    public AddressLinesResponse()
    {
      this.AddressLines = new List<Bm2s.Poco.Common.Partner.AddressLine>();
    }

    public List<Bm2s.Poco.Common.Partner.AddressLine> AddressLines { get; set; }
  }
}
