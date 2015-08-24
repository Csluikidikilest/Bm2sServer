using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.Partner
{
  public class PartnersResponse
  {
    public PartnersResponse()
    {
      this.Partners = new List<Bm2s.Poco.Common.Partner.Partner>();
    }

    public List<Bm2s.Poco.Common.Partner.Partner> Partners { get; set; }
  }
}
