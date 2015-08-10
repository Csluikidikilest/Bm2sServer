using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Partner.Address
{
  [Route("/bm2s/addresses", Verbs = "GET, POST")]
  [Route("/bm2s/addresses/{Ids}", Verbs = "GET")]
  public class Addresses : IReturn<AddressesResponse>
  {
    public Addresses()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public Bm2s.Data.Common.BLL.Partner.Address Address { get; set; }
  }
}
