using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Partner.Address
{
  [Route("/bm2s/addresses", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/addresses/{Ids}", Verbs = "GET")]
  public class Addresses : Request, IReturn<AddressesResponse>
  {
    public Addresses()
    {
      this.Ids = new List<int>();
    }

    public Bm2s.Poco.Common.Partner.Address Address { get; set; }
  }
}
